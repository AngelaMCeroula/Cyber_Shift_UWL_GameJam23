using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float gravity;
    public Vector2 velocity;
    public bool isWalkingLeft = true;

    private bool _grounded = false;

    public LayerMask floorMask;
    public LayerMask wallMask;
    
    

    private enum EnemyState
    {
        Walking,
        Falling,
        Dead
    }

    private EnemyState _state = EnemyState.Falling;
   

    void Start()
    {
        enabled = false;
        Fall();
    }

    private void Update()
    {
        UpdateEnemyPosition();
    }
    

    public void OnBecameVisible() //when gameObject becomes visible in the camera
    {
        Debug.Log("I SEE YOU");
        enabled = true;
        
    }

    void Fall()
    {
        velocity.y = 0;
        _state = EnemyState.Falling;
        _grounded = false;
    }

    void UpdateEnemyPosition()
    {
        if (_state != EnemyState.Dead)
        {
            Vector3 pos = transform.localPosition;
            Vector3 scale = transform.localScale;

            if (_state == EnemyState.Falling)
            {
                pos.y += velocity.y * Time.deltaTime;
                velocity.y -= gravity * Time.deltaTime;
            }

            if (_state == EnemyState.Walking)
            {
                if (isWalkingLeft)
                {
                    pos.x -= velocity.x * Time.deltaTime;
                    scale.x = -1;
                }
                else
                {
                    pos.x += velocity.x * Time.deltaTime;
                    scale.x = 1;

                }
                
            }

            if (velocity.y <= 0)
            {
                pos = CheckGround(pos);
            }
            
            CheckWalls(pos, scale.x);

            transform.localPosition = pos;
            transform.localScale = scale;
        }

    }
    
    Vector3 CheckGround(Vector3 pos)
    {
        Vector2 originLeft = new Vector2(pos.x - 0.5f + 0.2f, pos.y - .5f);
        Vector2 originMiddle = new Vector2(pos.x, pos.y - 0.5f);
        Vector2 originRight = new Vector2(pos.x + 0.5f - 0.2f, pos.y - .5f);

        RaycastHit2D groundLeft = Physics2D.Raycast(originLeft, Vector2.down, velocity.y * Time.deltaTime, floorMask);
        RaycastHit2D groundMiddle = Physics2D.Raycast(originMiddle, Vector2.down, velocity.y * Time.deltaTime, floorMask);
        RaycastHit2D groundRight = Physics2D.Raycast(originRight, Vector2.down, velocity.y * Time.deltaTime, floorMask);

        if (groundLeft.collider != null || groundMiddle.collider != null || groundRight.collider != null)
        {
            RaycastHit2D hitRay = groundLeft;

            if (groundLeft)
            {
                hitRay = groundLeft;
            }
            
            else if (groundMiddle)
            {
                hitRay = groundMiddle;
            }
            
            else if (groundRight)
            {
                hitRay = groundRight;
            }

            pos.y = hitRay.collider.bounds.center.y + hitRay.collider.bounds.size.y / 2 + .5f;

            _grounded = true;
            velocity.y = 0;
            _state = EnemyState.Walking;

        }

        else
        {
            if (_state != EnemyState.Falling)
            {
                Fall();
            }
            
        }

        return pos;
    }

    void CheckWalls(Vector3 pos, float direction)
    {
        Vector2 originTop = new Vector2(pos.x + direction * 0.4f, pos.y + .5f - 0.2f);
        Vector2 originMiddle = new Vector2(pos.x + direction * 0.4f, pos.y);
        Vector2 originBottom = new Vector2(pos.x + direction * 0.4f, pos.y - .5f + 0.2f);

        RaycastHit2D wallTop =
            Physics2D.Raycast(originTop, new Vector2(direction, 0), velocity.x * Time.deltaTime, wallMask);
        RaycastHit2D wallMiddle =
            Physics2D.Raycast(originMiddle, new Vector2(direction, 0), velocity.x * Time.deltaTime, wallMask);
        RaycastHit2D wallBottom =
            Physics2D.Raycast(originBottom, new Vector2(direction, 0), velocity.x * Time.deltaTime, wallMask);

        if (wallTop.collider != null || wallMiddle.collider != null || wallBottom.collider != null)
        {
            RaycastHit2D hitRay = wallTop;
            if (wallTop)
            {
                hitRay = wallTop;
            }
            else if (wallMiddle)
            {
                hitRay = wallMiddle;
            }
            else if (wallBottom)
            {
                hitRay = wallBottom;
            }

            isWalkingLeft = !isWalkingLeft;
        }
    }
    
}

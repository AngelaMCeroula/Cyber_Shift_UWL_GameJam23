using System;
using System.Collections;
using System.Collections.Generic;
using Player_Scripts;
using UnityEngine;

public class Player2DPlatformerController : MonoBehaviour
{
    
    private Rigidbody2D _rb;
    public float moveSpeed;
    public float jumpForce;
    
    public ProjectileBehaviour projectilePref;
    public Transform LaunchOffset;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    { 
        //Movement();
        ShootProjectile();
        
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * (Time.deltaTime * moveSpeed);

        if (!Mathf.Approximately(0, movement))
        {
            transform.rotation = movement > 0 ? Quaternion.Euler(0,180, 0) : Quaternion.identity;
        }

        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rb.velocity.y) < 0.001f)
        {
            _rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
    
    void ShootProjectile()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(projectilePref, LaunchOffset.position, transform.rotation);
        }
    }
}

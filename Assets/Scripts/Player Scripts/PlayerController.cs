using System.Collections;
using System.Collections.Generic;
using Player_Scripts;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
   private Rigidbody2D _rb;
    public float moveSpeed = 5.5f;
    public float jumpForce = 30;
    private Vector2 moveDirection;
    private float _yVector;
    private bool isGrounded;
    public float shootDelay;
    public UnityEvent OnLandingEvent;
    
    
    //lias code
    public Animator animator;
    
    
    
    
    
    //public Animator anim;
    
    public bool _facingRight = true;
    private float moveInput;

    public AudioClip playerJump;
    
    public AudioClip playerwalk;
    
    //shooting
    public ProjectileBehaviour projectilePrefLeft;
    public ProjectileBehaviour2 projectilePrefRight;
    public Transform LaunchOffset;
    private bool _recentlyshot;
    public PlayerHealthEnergy _PHE;
    
    


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();

    }
    
    void Update()
    {
        
        //lias code
        animator.SetFloat("Speed", Mathf.Abs(moveDirection.x));
        
        
        // _yVector = _rb.velocity.y;
        
        ProcessInputs();
        Jump();
        ShootProjectile();
        
        if(_rb.velocity.y == 0) //ESSENTIAL
        {
            isGrounded = true;
            if (Time.timeScale != 0)
            {
                //anim.SetBool("isRunning", false);
                animator.ResetTrigger("IsShot");
                animator.ResetTrigger("IsRunning");
                animator.ResetTrigger("IsJumping");
                animator.SetTrigger("IsIdle");
            }
        }

        if  (_rb.velocity.y == 0 && isGrounded == true && _rb.velocity.x == 0)
        {
            if (Time.timeScale != 0)
            {
                //anim.SetBool("isRunning", false);
                animator.ResetTrigger("IsShot");
                animator.ResetTrigger("IsRunning");
                animator.ResetTrigger("IsJumping");
                animator.SetTrigger("IsIdle");
            }
        }

        if (_rb.velocity.y != 0 && isGrounded == true)
        {
            if (Time.timeScale != 0)
            {
                //anim.SetBool("isRunning", true);
                Debug.Log("this should be running");
                animator.ResetTrigger("IsShot");
                animator.ResetTrigger("IsIdle");
                animator.ResetTrigger("IsJumping");
                animator.SetTrigger("IsRunning");
            }
        }

        if (_rb.velocity.y > 0)
        {
            if (Time.timeScale != 0)
            {
                //lias code
                Debug.Log("JUMP JUMP JUMP");
                //animator.ResetTrigger("IsRunning");
                animator.ResetTrigger("IsShot");
                animator.ResetTrigger("IsIdle");
                animator.ResetTrigger("IsRunning");
                animator.SetTrigger("IsJumping");
            }
        }
    }
    //lias code
    public void OnLanding()
    {
        if (Time.timeScale != 0)
        {
            animator.ResetTrigger("IsShot");
            animator.ResetTrigger("IsJumping");
            animator.ResetTrigger("IsRunning");
            animator.SetTrigger("IsIdle");
        }
    }
  
    
    
    
    void FixedUpdate()
    {
      
        Move();
        if (_facingRight && moveDirection.x < 0)
            Flip();
        else if (!_facingRight && moveDirection.x > 0)
            Flip();

    }
  
    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        moveDirection = new Vector2(moveX, _yVector);
    }
    void Move()
    {
        _rb.velocity = new Vector2(moveDirection.x * moveSpeed, _rb.velocity.y);
      
    }

 
 
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            //AudioSource.PlayClipAtPoint(playerJump, transform.position);
            //Debug.Log("NO JUMPING FOR YOU!" + isGrounded);
        }

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(!isGrounded)
        {
            if (col.gameObject.CompareTag("Ground"))
            {
                isGrounded = true;
               
            }
        }
    }

    void Flip()
    {
        _facingRight = !_facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }

    void ShootProjectile()
    {
        if (Input.GetButtonDown("Fire1") && _facingRight == false && _recentlyshot == false && _PHE.battery > 0 && Time.timeScale != 0)
        {
            animator.SetTrigger("IsShot");
            Instantiate(projectilePrefLeft, LaunchOffset.position, transform.rotation);
            StartCoroutine(Wait());
        }

        if (Input.GetButtonDown("Fire1") && _facingRight == true && _recentlyshot == false && _PHE.battery > 0 && Time.timeScale != 0)
        {
            animator.SetTrigger("IsShot");
            Instantiate(projectilePrefRight, LaunchOffset.position, transform.rotation);
            StartCoroutine(Wait());
        }
    }
    IEnumerator Wait()
    {
        _PHE.UseBat();
        _recentlyshot = true;
        yield return new WaitForSeconds(shootDelay);
        _recentlyshot = false;

    }
}
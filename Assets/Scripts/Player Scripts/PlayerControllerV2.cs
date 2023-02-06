using System.Collections;
using System.Collections.Generic;
using Player_Scripts;
using UnityEngine;

public class PlayerControllerV2 : MonoBehaviour
{
   private Rigidbody2D _rb;
    public float moveSpeed = 5.5f;
    public float jumpForce = 30;
    private Vector2 moveDirection;
    private float _yVector;
    private bool isGrounded;
    public float shootDelay;
    
    
    
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


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();

    }
    
    void Update()
    {
        ProcessInputs();
        Jump();
        ShootProjectile();
        
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
     if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(_rb.velocity.y) < 0.001f)
     {
         _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
         isGrounded = false;
         //AudioSource.PlayClipAtPoint(playerJump, transform.position);
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
     if (Input.GetButtonDown("Fire1") && _facingRight == false && _recentlyshot == false)
     {
         Instantiate(projectilePrefLeft, LaunchOffset.position, transform.rotation);
         StartCoroutine(Wait());
     }

     if (Input.GetButtonDown("Fire1") && _facingRight == true && _recentlyshot == false)
     {
         Instantiate(projectilePrefRight, LaunchOffset.position, transform.rotation);
         StartCoroutine(Wait());
     }
     
 }

 IEnumerator Wait()
 {
     GetComponent<PlayerHealthEnergy>().UseBat();
     _recentlyshot = true;
     yield return new WaitForSeconds(shootDelay);
     _recentlyshot = false;

 }
 
 

 private void Movement()
 {
     var movement = Input.GetAxis("Horizontal");
     transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * moveSpeed;

     if (!Mathf.Approximately(0, movement))
     {
         transform.rotation = movement > 0 ? Quaternion.Euler(0,180, 0) : Quaternion.identity;
     }

     if (Input.GetButtonDown("Jump") && Mathf.Abs(_rb.velocity.y) < 0.001f)
     {
         _rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
     }
 }
}



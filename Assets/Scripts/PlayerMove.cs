using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    Animator playerAnimator;

    public float moveSpeed = 5f; // Karakterin ileri hızı
    public float jumpSpeed = 1f, jumpFrequency=1f, nextjumpTime;

    bool facingRight = true;
    public bool isGrounded = false;

    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;
   


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        
    }

    void Update()
    {
        HorizontalMove();

        OnGroundCheck();
        if (rb.velocity.x < 0 && facingRight)
        {
            FlipFace();
        }
        else if(rb.velocity.x > 0 && !facingRight)
        {
            FlipFace();
        }

        if (Input.GetAxis("Vertical") > 0 && isGrounded && (nextjumpTime < Time.timeSinceLevelLoad))
        {
            nextjumpTime = Time.timeSinceLevelLoad + jumpFrequency;
            Jump();
        }
    }

    void HorizontalMove()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y);
        playerAnimator.SetFloat("playerWalkSpeed", Mathf.Abs(rb.velocity.x));
    }
   
    void FlipFace()
    {
        facingRight = !facingRight;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;

    }

    void Jump()
    {
        rb.AddForce(new Vector2(0f, jumpSpeed));
    }

    void OnGroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer);
        playerAnimator.SetBool("isGroundedAnim", isGrounded);
    } 
}

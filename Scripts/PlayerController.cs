using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRb;
    Animator playerAnimator;
    public float moveSpeed = 1f;
    public float jumpSpeed = 1f, jumpFrequency = 1f, nextJumpTime;

    bool facingRight = true;
    public bool isGrounded = false;
    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;

    //Script bir obje i�inde kullan�lmasa bile �al���r
    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMove();
        OnGroundCheck();

        if (playerRb.velocity.x < 0 && facingRight)
        {
            FlipFace();
        }
        else if (playerRb.velocity.x > 0 && !facingRight)
        {
            FlipFace();
        }

        if (Input.GetAxis("Vertical") > 0 && isGrounded && (nextJumpTime < Time.timeSinceLevelLoad))
        {
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;
            Jump();
        }

    }
    void FixedUpdate()
    {

    }

    void HorizontalMove()
    {
        playerRb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, playerRb.velocity.y);
        playerAnimator.SetFloat("playerSpeed", Mathf.Abs(playerRb.velocity.x));

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
        playerRb.AddForce(new Vector2(0f, jumpSpeed)); // add force ile kuvvet ekledik
    }

    void OnGroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer);
        playerAnimator.SetBool("isGroundedAnim", isGrounded);
    }
}


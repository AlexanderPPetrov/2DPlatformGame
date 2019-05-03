using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject
{

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private bool crouch = false;
    private bool running = false;
    private float factor = 1.0f;

    private bool facingRight = true;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }


        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        if (Input.GetButtonDown("Running") && grounded)
        {
            running = true;
            factor = 2.0f;
        }
        else if (Input.GetButtonUp("Running"))
        {
            running = false;
            factor = 1.0f;
        }

      //  bool flipSprite = (spriteRenderer.flipX ? (move.x > 0f) : (move.x < 0f));
       // if (flipSprite)
       // {
          //  transform.Rotate(0f, 180f, 0f);

       // }

        if(move.x > 0 && !facingRight || move.x < 0 && facingRight)
        {
            facingRight = !facingRight;

            transform.Rotate(0f, 180f, 0f);

        }

        if (animator)
        {
            animator.SetBool("grounded", grounded);
            animator.SetBool("crouching", crouch);
            animator.SetBool("running", running);
            
            animator.SetFloat("Speed", Mathf.Abs(velocity.x) * factor/ maxSpeed);
        }
  

        targetVelocity = move * factor * maxSpeed;
    }
}
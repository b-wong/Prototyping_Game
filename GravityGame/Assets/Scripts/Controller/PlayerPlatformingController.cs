using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformingController : PhysicsObject
{

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;

    public string jumpButton = "Player1Jump";
    public string horizontalCtrl = "Player1Horizontal";
    public string freezeButton = "Player1Freeze";
    public string gravSwapButton = "Player1Grav";

    //public bool isFrozen = false;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private PhysicsObject physObject;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        physObject = GetComponent<PhysicsObject>();
    }

    protected override void ComputeVelocity()
    {
        /*
        if (Input.GetButtonDown(freezeButton) && isFrozen == false)
        {
            isFrozen = true;
        }
        else if (Input.GetButtonDown(freezeButton) && isFrozen == true)
        {
            isFrozen = false;
        }
        if (isFrozen == true)
        {

            return;
        }
        */
        if (Input.GetButtonDown(freezeButton))
        {
            isFrozen = !isFrozen;
        }
        
        if (Input.GetButtonDown(gravSwapButton))
        {
            //toggle gravity swap
            //physObject.gravitySwapped = !physObject.gravitySwapped;
            gravitySwapped = !gravitySwapped;
        }

        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis(horizontalCtrl);

        if (Input.GetButtonDown(jumpButton) && grounded)
        {

            if (gravitySwapped == false)
            {
                velocity.y = jumpTakeOffSpeed;
            }
            else if (gravitySwapped == true)
            {
                velocity.y = -jumpTakeOffSpeed;
            }

        }

        /*
        if (Input.GetButtonDown(jumpButton) && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp(jumpButton))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }
        */

        /*
        if (gravitySwapped == false)
        {
            move = Vector2.up * deltaPosition.y;
        }
        else if (gravitySwapped == true)
        {
            move = Vector2.down * deltaPosition.y;
        }
        */

        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        //animator.SetBool("grounded", grounded);
        //animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
    }
}

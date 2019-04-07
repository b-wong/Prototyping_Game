using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformingController : PhysicsObject
{

    #region Components
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private PhysicsObject physObject;
    #endregion Components


    #region Speed modifiers
    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    #endregion Speed modifiers

    #region Input
    public string jumpButton = "Player1Jump";
    public string horizontalCtrl = "Player1Horizontal";
    public string freezeButton = "Player1Freeze";
    public string gravSwapButton = "Player1Grav";
    #endregion Input

    public static int numCollectable = 0;           //GravityCharges


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

    protected override void Update()
    {
        base.Update();
        InputHandling();

    }

    private void InputHandling()
    {
        if (Input.GetButtonDown(freezeButton))
        {
            isFrozen = !isFrozen;
        }

        if (Input.GetButtonDown(gravSwapButton))
        {
            TryUseCollectable();
            //toggle gravity swap
            //physObject.gravitySwapped = !physObject.gravitySwapped;
        }
    }

    private void TryUseCollectable()
    {
        if (GameManager.instance.gravitySwapCharges > 0)
        {
            GameManager.instance.gravitySwapCharges = GameManager.instance.gravitySwapCharges - 1;
            gravitySwapped = !gravitySwapped;

            //causes all physics objects to invert gravity
            Physics2D.gravity = -Physics2D.gravity;

        }
    }

    protected override void ComputeVelocity()
    {

        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis(horizontalCtrl);

        if (Input.GetButtonDown(jumpButton) && grounded)
        {


            // Reverse direction of jump force according to gravity swap direction.
            if (gravitySwapped == false)
            {
                velocity.y = jumpTakeOffSpeed;
            }
            else if (gravitySwapped == true)
            {
                velocity.y = -jumpTakeOffSpeed;
            }
        }

        // Flip sprite facing direction.
        if (move.x > 0.01f)
        {
            spriteRenderer.flipX = true;
        }
        else if (move.x < -0.01f)
        {
            spriteRenderer.flipX = false;
        }
        // Flip sprite on Y axis according to grav swap direction.
        if (gravitySwapped == true)
        {
            spriteRenderer.flipY = true;
        }
        else if (gravitySwapped == false)
        {
            spriteRenderer.flipY = false;
        }



        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);
        animator.SetBool("grounded", grounded);
        animator.SetBool("isFrozen", isFrozen);

        targetVelocity = move * maxSpeed;
    }

}

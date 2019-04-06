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

    int cur_FacingDirection = 1;

    //public bool isFrozen = false;



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

        //changes the facing direction of the character
        if (move.x > 0) cur_FacingDirection = 1;
        else if (move.x < 0) cur_FacingDirection = -1;
        transform.localScale = new Vector3(cur_FacingDirection, transform.localScale.y, transform.localScale.z);

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

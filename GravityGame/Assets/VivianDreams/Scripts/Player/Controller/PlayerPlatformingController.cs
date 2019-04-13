using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformingController : PhysicsObject
{
    public int playerNumber;


    #region Components
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private PhysicsObject physObject;

    [SerializeField]
    private PositionSwapper m_positionSwapper;

    #endregion Components


    #region Speed modifiers
    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    #endregion Speed modifiers
    

    bool canFreeze = true;
    bool canGravSwap = true;
    bool canSwapPos = true;
    

    #region Input
    public string jumpButton = "Player1Jump";
    public string horizontalCtrl = "Player1Horizontal";
    public string freezeButton = "Player1Freeze";
    public string gravSwapButton = "Player1Grav";
    public string positionSwapButton = "Player1PositionSwap";

    //Controller Input
    private string horizontalAxis = "_axis_horizontal_ctrl";
    private string jumpAxis = "_jump_ctrl";
    private string freezeAxis = "_freeze_ctrl";
    private string gravAxis = "_grav_ctrl";
    private string positionSwapAxis = "_positionSwap_ctrl";

    #endregion Input

    public static int numCollectable = 0;           //GravityCharges


    // Use this for initialization
    void Awake()
    {
        m_positionSwapper = GameObject.FindWithTag("PositionSwapper").GetComponent<PositionSwapper>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        positionSwapButton = string.Format("Player{0}PositionSwap", playerNumber);
        physObject = GetComponent<PhysicsObject>();
    }

    protected override void Update()
    {
        base.Update();
        InputHandling();
    }

    float timeBetweenFreeze;
    float timeBetweenGrav;

    private void InputHandling()
    {
        //controller Input
        bool FreezeAxis = Input.GetButtonDown(playerNumber + freezeAxis);
        bool GravSwapAxis = Input.GetButtonDown(playerNumber + gravAxis);
        bool SwapPositionAxis = Input.GetButtonDown(playerNumber + positionSwapAxis);

        if (Input.GetButtonDown(freezeButton) || FreezeAxis)
        {
            isFrozen = !isFrozen;
        }

        if (Input.GetButtonDown(gravSwapButton) || GravSwapAxis)
        {
            TryUseCollectable();
            //toggle gravity swap
            //physObject.gravitySwapped = !physObject.gravitySwapped;
        }

        if (Input.GetButtonDown(positionSwapButton) || SwapPositionAxis)
        {
            if (playerNumber == 1)
                m_positionSwapper.player1SwapPos = !m_positionSwapper.player1SwapPos;
            else
                m_positionSwapper.player2SwapPos = !m_positionSwapper.player2SwapPos;
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

        if (Input.GetAxis(horizontalCtrl) != 0)
            move.x = Input.GetAxis(horizontalCtrl);                     //keyboard input
        if (Input.GetAxis(playerNumber + horizontalAxis) != 0)
            move.x = Input.GetAxis(playerNumber + horizontalAxis);      //controller input

        bool jumpButtonCheck = Input.GetButtonDown(jumpButton);
        float jumpAxisCheck = Input.GetAxis(playerNumber + jumpAxis);
        
        if ((jumpButtonCheck || jumpAxisCheck > 0) && grounded)
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


        targetVelocity = move * maxSpeed;

        animator.SetFloat("velocityX", Mathf.Abs(targetVelocity.x) / maxSpeed);
        animator.SetBool("grounded", grounded);
        animator.SetBool("isFrozen", isFrozen);        
    }

}

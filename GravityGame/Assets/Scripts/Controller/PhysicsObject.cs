using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{

    public float minGroundNormalY = .65f;
    public float gravityModifier = 1f;



    Vector2 gravityUp = new Vector2(0, 9.8f);
    Vector2 gravityDown = new Vector2(0, -9.8f);
    Vector2 gravityDirection = new Vector2(0, -9.8f);
    public bool gravitySwapped = false;
    public bool isFrozen = true;

    protected Vector2 targetVelocity;
    protected bool grounded;
    protected Vector2 groundNormal;
    protected Rigidbody2D rb2d;
    public Vector2 velocity;
    protected ContactFilter2D contactFilter;
    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
    protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D>(16);


    protected const float minMoveDistance = 0.001f;
    protected const float shellRadius = 0.01f;

    void OnEnable()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }


    private void Awake()
    {
        // Add this object to static list so it may be grouped with others in level
        PhysicsManager.instance.physicsObjects.Add(this);
    }

    void Start()
    {
        //gravityDirection = gravityDown;
        contactFilter.useTriggers = false;
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        contactFilter.useLayerMask = true;
    }

    void Update()
    {
        GravitySwap();
        targetVelocity = Vector2.zero;
        ComputeVelocity();

    }

    protected virtual void ComputeVelocity()
    {

    }

    void FixedUpdate()
    {

        //gravityDirection = gravityDown;

        //gravity swap

        if (gravitySwapped == false || isFrozen == true)
        {
            gravityDirection = gravityDown;
        }
        else if (gravitySwapped == true)
        {
            gravityDirection = gravityUp;
        }

        /*foreach (PhysicsObject item in PhysicsManager.instance.physicsObjects)
        {

        }*/

        if (isFrozen == true)
        {
            return;
        }

        velocity += gravityModifier * gravityDirection * Time.deltaTime;
        velocity.x = targetVelocity.x;

        grounded = false;

        Vector2 deltaPosition = velocity * Time.deltaTime;

        Vector2 moveAlongGround = new Vector2(Mathf.Abs(groundNormal.y), -groundNormal.x);

        Vector2 move = moveAlongGround * deltaPosition.x;

        Movement(move, false);

        move = Vector2.up * deltaPosition.y;

        Movement(move, true);


    }

    void Movement(Vector2 move, bool yMovement)
    {
        float distance = move.magnitude;

        if (distance > minMoveDistance)
        {
            int count = rb2d.Cast(move, contactFilter, hitBuffer, distance + shellRadius);
            hitBufferList.Clear();
            for (int i = 0; i < count; i++)
            {
                hitBufferList.Add(hitBuffer[i]);
            }

            for (int i = 0; i < hitBufferList.Count; i++)
            {
                Vector2 currentNormal = hitBufferList[i].normal;


                if (Mathf.Abs(currentNormal.y) > minGroundNormalY)
                {
                    grounded = true;
                    if (yMovement)
                    {
                        groundNormal = currentNormal;
                        currentNormal.x = 0;
                    }
                }


                float projection = Vector2.Dot(velocity, currentNormal);
                if (projection < 0)
                {
                    velocity = velocity - projection * currentNormal;
                }

                float modifiedDistance = hitBufferList[i].distance - shellRadius;
                distance = modifiedDistance < distance ? modifiedDistance : distance;
            }


        }

        rb2d.position = rb2d.position + move.normalized * distance;
    }

    public void GravitySwap()
    {
        

        
    }

}


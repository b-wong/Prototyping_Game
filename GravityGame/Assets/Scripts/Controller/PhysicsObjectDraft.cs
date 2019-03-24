using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObjectDraft : MonoBehaviour
{
    public float minGroundNormalY = 0.65f;
    public Vector2 velocity;
    bool isGrounded;
    Vector2 groundNormal;

    Vector2 gravityUp = new Vector2(0, 9.8f);
    Vector2 gravityDown = new Vector2(0, -9.8f);
    Vector2 gravitySwap;

    public float gravityModifier = 1f;

    public Rigidbody2D rigidbody2d;

    bool isFrozen;
    public const float minMoveDistance = 0.001f;
    public const float skinRadius = 0.01f;
    public ContactFilter2D contactFilter;
    public RaycastHit2D[] collisionBufferArray = new RaycastHit2D[16];
    public List<RaycastHit2D> collisionBufferList = new List<RaycastHit2D>(16);


    private void Start()
    {
        isFrozen = false;
        gravitySwap = gravityDown;

        contactFilter.useTriggers = false;
        // Uses Physics2D layer settings to check collisions
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        contactFilter.useLayerMask = true;
    }
    // Initialize rigidbody reference
    private void OnEnable()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {

        /*
        if (isFrozen == true)
        {
            return;
        }*/

        // Uses default Phys2D gravity to affect velocity at an increasing rate
        velocity += gravityModifier * gravitySwap * Time.deltaTime;

        isGrounded = false;

        // Uses delta position to predict momentum
        Vector2 deltaPosition = velocity * Time.deltaTime;

        Vector2 move = Vector2.up * deltaPosition.y;

        Movement(move, true);
        GravitySwap();

    }

    void Movement(Vector2 move, bool yMovement)
    {
        float distance = move.magnitude;
        // This will check for possible collisions before calculating next move position
        if (distance > minMoveDistance)
        {
            int count = rigidbody2d.Cast(move, contactFilter, collisionBufferArray, distance + skinRadius);

            collisionBufferList.Clear();
            // Find active collision contacts
            for (int i = 0; i < count; i++)
            {
                collisionBufferList.Add(collisionBufferArray[i]);
            }

            // Check angle of collision
            for (int i = 0; i < collisionBufferList.Count; i++)
            {
                Vector2 currentNormal = collisionBufferList[i].normal;
                if (currentNormal.y > minGroundNormalY)
                {
                    isGrounded = true;
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
                float modifiedDistance = collisionBufferList[i].distance - skinRadius;
                distance = modifiedDistance < distance ? modifiedDistance : distance;
            }

        }
        // Moves on y axis by provided move value
        rigidbody2d.position = rigidbody2d.position + move.normalized * distance;
    }

    void GravitySwap()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (gravitySwap == gravityDown)
            { gravitySwap = gravityUp; }
            else if (gravitySwap == gravityUp)
            { gravitySwap = gravityDown; }

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithPlatform : MonoBehaviour
{
    PhysicsObject physics;


    private void Awake()
    {
        physics = GetComponent<PhysicsObject>();
    }

 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.LogFormat("Collision {0} {1} {2}", collision.otherCollider.tag, collision.collider.tag, collision.contacts[0].normal);

        if (collision.collider.CompareTag("MovingPlatform") && collision.contacts[0].normal.y > 0.7f)
        {
            physics.relativeTo = collision.rigidbody;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag("MovingPlatform"))
        {
            if (physics != null)
                physics.relativeTo = null;
        }
    }

}

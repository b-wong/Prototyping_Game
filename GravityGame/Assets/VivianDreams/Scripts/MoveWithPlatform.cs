using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithPlatform : MonoBehaviour
{

    [SerializeField]
    GameObject playerHolder;

    PhysicsObject physics;


    private void Awake()
    {
        playerHolder = GameObject.FindWithTag("PlayerHolder");
        physics = GetComponent<PhysicsObject>();
    }

 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.LogFormat("Collision {0} {1} {2}", collision.otherCollider.tag, collision.collider.tag, collision.contacts[0].normal);

        if (collision.collider.CompareTag("MovingPlatform") && collision.contacts[0].normal.y > 0.7f)
        {
            if (physics == null)
            {
                gameObject.transform.parent.SetParent(collision.gameObject.transform);
            } else
            {
                physics.relativeTo = collision.rigidbody;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag("MovingPlatform"))
        {
            gameObject.transform.parent.SetParent(playerHolder.transform);
            if (physics != null)
                physics.relativeTo = null;
        }
    }

}

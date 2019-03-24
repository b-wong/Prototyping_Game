using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IrvinsGravityChange : MonoBehaviour
{ 

        Vector2 gravity = new Vector2(0, -5);

        Rigidbody2D rb2d;

        void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();
        }

        //public void GravityAdd()
        public void GravityChange()
        {
            // rb2d.AddForce(gravity);

            if (Input.GetKey("down"))
            {
                gravity = new Vector2(0, -5);
            }
            if (Input.GetKey("up"))
            {
                gravity = new Vector2(0, 5);
            }
            if (Input.GetKey("right"))
            {
                gravity = new Vector2(5, 0);
            }
            if (Input.GetKey("left"))
            {
                gravity = new Vector2(-5, 0);
            }

            Physics2D.gravity = gravity;
        }

        private void Update()
        {
            //GravityAdd();
            GravityChange();
        }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Billiards
{
    [RequireComponent(typeof(Rigidbody))]
    public class Ball : MonoBehaviour
    {
        public float stopSpeed = 0.2f;

        private Rigidbody rigid;

        // Use this for initialization
        void Start()
        {
            rigid = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            Vector3 vel = rigid.velocity;

            // Check if velocity is going up
            if(vel.y > 0)
            {
                // Cap velocity
                vel.y = 0;
            }

            // If the velocity's speed is less than the stop speed
            if(vel.magnitude < stopSpeed)
            {
                // Cancel out velocity
                vel = Vector3.zero;
            }

            // Apply desired 'vel' to rigid's velocity
            rigid.velocity = vel;
        }

        // Perform physics impact
        public void Hit(Vector3 direction, float impactForce)
        {
            rigid.AddForce(direction * impactForce, ForceMode.Impulse);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Breakout
{
    public class Ball : MonoBehaviour
    {
        public float speed = 5f; // Speed at which the ball travels
        public GameManager gameManager;

        private Vector3 velocity; // Direction x Speed

        // Send the ball flying in a given direction
        public void Fire(Vector3 direction)
        {
            velocity = direction * speed;
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            // Grab the contact point of collision
            ContactPoint2D contact = other.contacts[0];
            // Calculate reflect using velocity and normal
            Vector3 reflect = Vector3.Reflect(velocity, contact.normal);
            // Redirecting the velocity to reflection
            velocity = reflect.normalized * velocity.magnitude;

            // If we hit a block
            if(other.gameObject.tag == "Block")
            {
                // Destroy that block
                Destroy(other.gameObject);
                // Increase score via gameManager
                gameManager.IncreaseScore();
            }
        }

        // Update is called once per frame
        void Update()
        {
            // Move position based on velocity
            transform.position += velocity * Time.deltaTime;
        }
    }
}

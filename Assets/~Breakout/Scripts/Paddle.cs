using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Breakout
{
    public class Paddle : MonoBehaviour
    {
        public float movementSpeed = 20f;
        public Ball currentBall;

        public Vector3[] directions = new Vector3[]
        {
            new Vector3(.5f, .5f), // index 0
            new Vector3(-.5f, .5f) // index 1
        };

        // Use this for initialization
        void Start()
        {
            currentBall = GetComponentInChildren<Ball>();
        }

        void Fire()
        {
            // Detatch children (Ball)
            currentBall.transform.SetParent(null); // ... I'm batman
            // Randomly select a direction
            Vector3 randomDir = directions[Random.Range(0, directions.Length)];
            // Fire off the ball in the random direction
            currentBall.Fire(randomDir);
        }

        void CheckInput()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Fire();
            }
        }

        void Movement()
        {
            // Get input axis horizontal
            float inputH = Input.GetAxis("Horizontal");
            // Set force to direction (inputH to decide which direction)
            Vector3 force = transform.right * inputH;
            // Apply movementSpeed to force
            force *= movementSpeed;
            // Apply delta time to force
            force *= Time.deltaTime;
            // Add the force to postion
            transform.position += force;
        }

        // Update is called once per frame
        void Update()
        {
            CheckInput();
            Movement();
        }

    }
}

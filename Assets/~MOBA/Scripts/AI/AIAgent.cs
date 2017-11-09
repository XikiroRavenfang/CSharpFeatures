﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

namespace MOBA
{
    public class AIAgent : MonoBehaviour
    {
        public float maxSpeed = 10f;
        public float maxDistance = 5f;
        public bool updatePosition = true;
        public bool updateRotation = true;

        [HideInInspector]
        public Vector3 velocity;

        private Vector3 force;
        private List<SteeringBehaviour> behaviours;
        private NavMeshAgent nav;

        // Initialisation
        void Awake()
        {
            nav = GetComponent<NavMeshAgent>();
            behaviours = new List<SteeringBehaviour>(GetComponents<SteeringBehaviour>());
        }

        // Calculates all forces from attached SteeringBehaviours
        void ComputeForces()
        {
            // Reset force before calculation
            force = Vector3.zero;
            // Loop through all behaviours
            for (int i = 0; i < behaviours.Count; i++)
            {
                // Get current behaviour
                SteeringBehaviour b = behaviours[i];
                // Check if behaviour is not active and enabled
                if (!b.isActiveAndEnabled)
                {
                    // Skip over the next behaviour
                    continue;
                }
                // Apply behaviour's force to our final force
                force += b.GetForce() * b.weighting;
                // Check if force has gone over maxSpeed
                if (force.magnitude > maxSpeed)
                {
                    // Cap the force down to maxSpeed
                    force = force.normalized * maxSpeed;
                    // Exit for loop
                    break;
                }
                   
            }
        }

        // Applies the velocity to agent
        void ApplyVelocity()
        {

        }

        // Update
        void Update()
        {

        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace AI
{
    public class AIAgent : MonoBehaviour
    {
        public Vector3 force;
        public Vector3 velocity;
        public float maxVelocity = 100f;
        public float maxDistance = 10f;
        public bool freezeRotation = false;

        private NavMeshAgent nav;
        private List<SteeringBehaviour> behaviours;

        // Use this for initialization
        void Start()
        {
            behaviours = new List<SteeringBehaviour>(GetComponents<SteeringBehaviour>());
        }

        void ComputeForces()
        {
            // SET force = Vector3.zero
            force = Vector3.zero;
            // FOR i := to behaviours.Count
            for (int i = 0; i < behaviours.Count; i++)
            {
                SteeringBehaviour behaviour = behaviours[i];
                if (!behaviour.isActiveAndEnabled)
                {
                    continue;
                }
                force = force + behaviour.GetForce() * behaviour.weighting;
                if (force.magnitude > maxVelocity)
                {
                    force = force.normalized * maxVelocity;
                    break;
                }
            }
                // IF behaviour.isActive == false
                    // continue
                // SET force = force + behaviour.GetForce() x weighting
                // IF force.magnitude > maxVelocity
                    // SET force = force.normalized x maxVelocity
                    // break
        }

        void ApplyVelocity()
        {
            // SET velocity = velocity + force x deltaTime
            velocity = velocity + force * Time.deltaTime;
            // IF velocity > maxVelocity
            if (velocity.magnitude > maxVelocity)
            {
                velocity = velocity.normalized * maxVelocity;
            }
            // SET velocity = velocity.normalized x maxVelocity
            // IF velocity.magnitude > 0
            if (velocity.magnitude > 0)
            {
                transform.position = transform.position + velocity * Time.deltaTime;
                transform.rotation = Quaternion.LookRotation(velocity);
            }
                // SET transform.position = transform.position + velocity x deltaTime
                // SET transform.rotation = Quaternion LookRotation (velocity)
            
        }

        // Update is called once per frame
        void Update()
        {
            ComputeForces();
            ApplyVelocity();
        }
    }
}

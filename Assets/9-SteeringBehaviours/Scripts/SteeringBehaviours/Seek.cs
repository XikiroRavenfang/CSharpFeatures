using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class Seek : SteeringBehaviour
    {
        public Transform target;
        public float stoppingDistance = 1f;

        public override Vector3 GetForce()
        {
            // SET force to Vector3 zero
            Vector3 force = Vector3.zero;
            // If target == null
            if (target == null)
            {
                return force;
            }
            // Return force

            // LET desiredForce = target.position - transform.position
            Vector3 desiredForce = target.position - transform.position;
            // IF desiredForce magnitude > stoppingDistance
            if (desiredForce.magnitude > stoppingDistance)
            {
                desiredForce = desiredForce.normalized * weighting;
                force = desiredForce - owner.velocity;
            }
                // desiredForce = desiredForce normalized x weighting
                // force = desiredForce - owner.velocity

            // Return force
            return force;
        }
    }
}

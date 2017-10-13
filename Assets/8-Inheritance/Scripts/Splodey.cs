using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inheritance
{
    public class Splodey : Enemy
    {
        [Header("Splodey")]
        public float splosionRadius = 5f;
        public float splosionRate = 3f;
        public float impactForce = 10f;
        public GameObject splosionParticles;

        private float splosionTimer = 0f;
        private bool isIgnited = false;

        public override void Attack()
        {
            // Start ignition timer
            isIgnited = true;
            // If splosionTimer > splosionRate
            // Call Explode()
        }

        protected override void Update()
        {
            base.Update();
            if (isIgnited)
            {
                Ignition();
            }
        }

        void Ignition()
        {
            float distance = Vector3.Distance(transform.position, target.position);
            if (distance > attackRange)
            {
                print("derp");
                isIgnited = false;
                splosionTimer = 0;
            }
            else
            {
                splosionTimer += Time.deltaTime;
                if (splosionTimer >= splosionRate)
                {
                    Explode();
                }
            }
        }

        void Explode()
        {
            print("test");
            Collider[] hits = Physics.OverlapSphere(transform.position, splosionRadius);
            foreach (Collider hit in hits)
            {
                if (hit.tag == "Player")
                {
                    Vector3 direction = target.position - transform.position;
                    Rigidbody playerRigi = hit.GetComponent<Rigidbody>();
                    playerRigi.AddForce(direction.normalized * impactForce, ForceMode.Impulse);
                }
            }
            Destroy(gameObject);
            // Perform Physics OverlapSphere with splosionRadius
            // Loop through all hits
            // If player
            // Add impact force to rigidbody

            // Destroy self
        }
    }
}

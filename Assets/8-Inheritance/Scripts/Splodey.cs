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

        protected override void OnAttackEnd()
        {
            // If splosionTimer > splosionRate
            if (splosionTimer > splosionRate)
            {
                Splode();
                // Destroy self
                Destroy(gameObject);
            }
        }

        protected override void Update()
        {
            base.Update();
            // Start ignition timer
            splosionTimer += Time.deltaTime;
        }

        void Splode()
        {
            // Perform Physics OverlapSphere with splosionRadius
            Collider[] hits = Physics.OverlapSphere(transform.position, splosionRadius);
            // Loop through all hits
            foreach (var hit in hits)
            {
                Health h = hit.GetComponent<Health>();
                if (hit.tag == "Player")
                {
                    if (h != null)
                    {
                        h.TakeDamage(damage);
                    }
                    Rigidbody r = hit.GetComponent<Rigidbody>();
                    {
                        r.AddExplosionForce(impactForce, transform.position, splosionRadius);
                    }
                }
            }
        }
    }
}

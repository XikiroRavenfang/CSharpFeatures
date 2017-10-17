using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inheritance
{
    public class Charger : Enemy
    {
        [Header("Charger")]
        public float impactForce = 10f;
        public float knockback = 5f;

        //private Rigidbody rigid;

        protected override void Attack()
        {
            // Add force to self
            rigid.AddForce(transform.forward, ForceMode.Impulse);
        }

        void OnCollisionEnter(Collision col)
        {
            Health h = col.gameObject.GetComponent<Health>();
            if (h != null)
            {
                h.TakeDamage(damage);
            }
            Rigidbody r = col.gameObject.GetComponent<Rigidbody>();
            if (r != null)
            {
                Vector3 direction = target.position - transform.position;
                r.AddForce(direction.normalized * impactForce, ForceMode.Impulse);
                rigid.AddForce(-transform.forward * knockback, ForceMode.Impulse);
            }

            // If collision hits player
                // Add impactForce to player
        }
    }
}

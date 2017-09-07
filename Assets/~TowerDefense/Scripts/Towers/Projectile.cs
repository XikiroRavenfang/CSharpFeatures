using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Projectile : MonoBehaviour
    {
        public float damage = 50f; // Damage dealt to whatever gets hit
        public float speed = 50f; // Speed the projectile travels
        public Vector3 direction; // Direction the projectile travels

        // Update is called once per frame
        void Update()
        {
            Vector3 velocity = direction.normalized * speed;
            transform.position += velocity * Time.deltaTime;
        }

        void OnTriggerEnter(Collider col)
        {
            Enemy e = col.gameObject.GetComponent<Enemy>();
            if(e != null)
            {
                e.DealDamage(damage);
                Destroy(gameObject);
            }

            if(col.name == "Ground")
            {
                Destroy(gameObject);
            }
        }
    }
}
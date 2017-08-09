using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Functions
{
    public class Shooting : MonoBehaviour
    {
        // Stores the object we want to Instantiate
        public GameObject projectilePrefab;
        // Speed at which the projectile will be flung
        public float projectileSpeed = 20f;
        // Recoil for the player
        public float recoil = 30f;
        // Rate of fire
        public float shootRate = 0.1f;
        // Timer to count up to shootRate
        private float shootTimer = 0f;
        // Container for the Rigidbody2D
        private Rigidbody2D rigid;

        // Use this for initialization
        void Start()
        {
            // Get the rigidbody componenet
            rigid = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            // Increase the timer
            shootTimer += Time.deltaTime;
            // AND = &&
            // OR = ||

            // IF space bar is pressed AND shootTimer >= shootRate
            if (Input.GetKey(KeyCode.Space) && shootTimer >= shootRate)
            {
                // CALL Shoot()
                Shoot();
                // RESET shootTimer = 0
                shootTimer = 0f;
            }
        }

        void Shoot()
        {
            // Instantiate a new copy of projectilePrefab
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            // Apply a force to the projectile
            Rigidbody2D projectileRigid = projectile.GetComponent<Rigidbody2D>();
            projectileRigid.AddForce(transform.right * projectileSpeed, ForceMode2D.Impulse);
            // Apply a recoil to the player
            rigid.AddForce(-transform.right * recoil, ForceMode2D.Impulse);
        }
    }
}

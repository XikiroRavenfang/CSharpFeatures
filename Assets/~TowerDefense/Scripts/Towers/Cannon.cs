using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Cannon : MonoBehaviour
    {
        public Transform barrel; // Reference to barrel where bullet will be shot from
        public GameObject projectilePrefab; // Prefab of projectile to instantiate when firing

        public void Fire(Enemy targetEnemy)
        {
            Vector3 targetPos = targetEnemy.transform.position;
            Vector3 barrelPos = barrel.transform.position;
            Quaternion barrelRot = barrel.transform.rotation;
            Vector3 fireDirection = targetPos - barrelPos;

            transform.rotation = Quaternion.LookRotation(fireDirection, Vector3.up);

            GameObject clone = Instantiate(projectilePrefab, barrelPos, barrelRot);
            Projectile p = clone.GetComponent<Projectile>();
            p.direction = fireDirection;
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Inheritance
{
    public class Enemy : MonoBehaviour
    {
        [Header("Enemy")]
        public Transform target;
        public int health = 100;
        public int damage = 20;
        public float attackDuration = 1f;
        public float attackRange = 2f;
        public float attackRate = 0.5f;

        protected NavMeshAgent nav;
        protected Rigidbody rigid;

        private float attackTimer = 0f;

        protected virtual void Awake()
        {
            nav = GetComponent<NavMeshAgent>();
            rigid = GetComponent<Rigidbody>();
        }

        protected virtual void Attack() { }
        protected virtual void OnAttackEnd() { }

        IEnumerator AttackDelay(float delay)
        {
            // stop navigation
            nav.Stop();
            yield return new WaitForSeconds(delay);
            if (nav.isOnNavMesh)
            {
                // resume navigation
                nav.Resume();
            }
            // call OnAttackEnd()
            OnAttackEnd();
        }

        protected virtual void Update()
        {
            if (target == null)
            {
                return;
            }
            // Increase attack timer
            attackTimer += Time.deltaTime;
            // If attackTimer >= attackRate
            if (attackTimer >= attackRate)
            {
                // Navigate to target
                nav.SetDestination(target.position);
                // Get distance from enemy to target
                float distance = Vector3.Distance(transform.position, target.position);
                // If distance < attack range
                if (distance < attackRange)
                {
                    // Call Attack()
                    Attack();
                    // Reset attack timer
                    attackTimer = 0f;
                    // StartCoroutine for attack delay
                    StartCoroutine(AttackDelay(attackDuration));
                }
            }
        }
    }
}

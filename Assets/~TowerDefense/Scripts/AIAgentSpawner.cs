using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class AIAgentSpawner : MonoBehaviour
    {
        public GameObject aiAgentPrefab; // prefab of AI Agent
        public Transform target; // Target that each AI Agent should travel to
        public float spawnRate = 1f; // Rate of spawn
        public float spawnRadius = 1f; // Radius of spawn

        // Visualization code
        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            // Draw a sphere to indicate the spawn radius
            Gizmos.DrawWireSphere(transform.position, spawnRadius);
        }

        void Spawn()
        {
            GameObject clone = Instantiate(aiAgentPrefab);
            Vector3 rand = Random.insideUnitSphere;
            rand.y = 0;
            clone.transform.position = transform.position + rand * spawnRadius;
            AIAgent aiAgent = clone.GetComponent<AIAgent>();
            aiAgent.target = target;
        }

        // Use this for initialization
        void Start()
        {
            InvokeRepeating("Spawn", 0, spawnRate);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

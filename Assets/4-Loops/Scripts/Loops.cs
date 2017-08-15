using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoopsArrays
{
    public class Loops : MonoBehaviour
    {
        public GameObject[] spawnPrefabs;
        public float amplitude = 6f;
        public float frequency = 5f;
        public float spawnRadius = 5f;
        public string message = "Print This";
        public float printTime = 2f;
        public int spawnAmount = 10;

        private float timer;

        void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, spawnRadius);
        }

        // Use this for initialization
        void Start()
        {
            /*
            While (Condition)
            {
                Statement
            }
            */
            SpawnObjectsWithSine();
        }

        // Update is called once per frame
        void Update()
        {
            /*
            timer += Time.deltaTime;
            while (true)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    break;
                }
            }
            */
        }

        void SpawnObjectsWithSine()
        {
        for (int i = 0; i < spawnAmount; i++)
            {
                // Spawned new game object
                int randomIndex = Random.Range(0, spawnPrefabs.Length);
                GameObject randomPrefab = spawnPrefabs[randomIndex];
                GameObject clone = Instantiate(randomPrefab);
                // Grab the MeshRenderer
                MeshRenderer rend = clone.GetComponent<MeshRenderer>();
                // Change the color
                float r = Random.Range(0, 2);
                float g = Random.Range(0, 2);
                float b = Random.Range(0, 2);
                rend.material.color = new Color(r, g, b);
                // Generated random position within circle
                float x = Mathf.Sin(i * frequency) * amplitude;
                float y = i;
                float z = Mathf.Cos(i * frequency) * amplitude;
                Vector3 randomPos = transform.position + new Vector3(x, y, z);
                // Set spawned objects positions
                clone.transform.position = randomPos;
            }
        }

        void SpawnObjects()
        {
        /*
            for (initialization; condition; iteration0
            {
                statement
            }
        
        for (int i = 0; i < spawnAmount; i++)
            {
                // Spawned new game object
                GameObject clone = Instantiate(spawnPrefab);
                // Generated random position within circle
                Vector3 randomPos = transform.position + Random.insideUnitSphere * spawnRadius;
                // Cancel out the z
                randomPos.z = 0;
                // Set spawned objects positions
                clone.transform.position = randomPos;
            }
        */
        }
    }
}

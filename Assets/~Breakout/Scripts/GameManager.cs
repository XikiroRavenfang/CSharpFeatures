using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakOut
{
    public class GameManager : MonoBehaviour
    {
        public int width = 20;
        public int height = 20;
        public GameObject[] blockPrefabs;

        // Use this for initialization
        void Start()
        {
            GenerateBlocks();
        }

        GameObject GetRandomBlock()
        {
            // Randomly spawn a new GameObject
            int randomIndex = Random.Range(0, blockPrefabs.Length);
            GameObject randomPrefab = blockPrefabs[randomIndex];
            GameObject clone = Instantiate(randomPrefab);
            // ... and return it
            return clone;
        }

        void GenerateBlocks()
        {
            // Loop through the width
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    // Create a new instance of the block
                    GameObject block = GetRandomBlock();
                    // Set the new position
                    Vector3 pos = new Vector3(x, y, 0);
                    block.transform.position = pos;
                }
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

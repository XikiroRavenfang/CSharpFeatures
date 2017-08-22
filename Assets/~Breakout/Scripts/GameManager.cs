﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Breakout
{
    public class GameManager : MonoBehaviour
    {
        public int width = 20;
        public int height = 20;
        public Vector2 spacing = new Vector2(25f, 10f);
        public Vector2 offset = new Vector2(25f, 10f);
        public GameObject[] blockPrefabs;
        [Header("Debugging")]
        public bool isDebugging = false;

        private GameObject[,] spawnedBlocks;

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
            spawnedBlocks = new GameObject[width, height];
            // Loop through the width
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    // Create a new instance of the block
                    GameObject block = GetRandomBlock();
                    // Set the new position
                    Vector2 pos = new Vector3(x * spacing.x, y * spacing.y);
                    pos += offset;
                    GameObject currentBlock = spawnedBlocks[x, y];
                    block.transform.position = pos;
                    // Add block to 2D array
                    spawnedBlocks[x, y] = block;
                }
            }
        }

        void UpdateBlocks()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Vector2 pos = new Vector3(x * spacing.x, y * spacing.y);
                    pos += offset;
                    GameObject currentBlock = spawnedBlocks[x, y];
                    currentBlock.transform.position = pos;
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (isDebugging)
            {
                UpdateBlocks();
            }
        }
    }
}

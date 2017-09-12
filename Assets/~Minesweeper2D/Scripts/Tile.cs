using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minesweeper2D
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Tile : MonoBehaviour
    {
        // Store x and y coordinate in array for later use
        public int x = 0;
        public int y = 0;
        public bool isMine = false; // Is the current tile a mine?
        public bool isRevealed = false; // Has the tile already been revealed?
        [Header("References")]
        public Sprite[] emptySprites; // List of empty sprites i.e, empty, 1, 2, 3, 4, etc...
        public Sprite[] mineSprites; // The mine sprites
        public Sprite baseSprite;
        public Sprite flagSprite;

        private SpriteRenderer rend;
        private bool isFlagged = false;

        void Awake()
        {
            // Grab reference to sprite renderer
            rend = GetComponent<SpriteRenderer>();
        }

        // Use this for initialization
        void Start()
        {
            // Randomly decide if it's a mine or not
            isMine = Random.value < .075f;
        }

        public void Reveal(int adjacentMines, int mineState = 0)
        {
            // Flags the tile as being revealed
            isRevealed = true;
            if (isMine)
            {
                // Sets sprite to mine sprite
                rend.sprite = mineSprites[mineState];
            }
            else
            {
                // Sets sprite to appropriate texture based on adjacent mines
                rend.sprite = emptySprites[adjacentMines];
            }
        }

        public void ToggleFlag()
        {
            isFlagged = !isFlagged;
            if(isFlagged)
            {
                rend.sprite = flagSprite;
            }
            else
            {
                rend.sprite = baseSprite;
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Unity.FPS.Game.UpgradeTiles
{
    public class TileProperties : MonoBehaviour
    {
        public enum TileShape
        {
            OneByOne,
            TwoByOne,
            TwoByTwo,
            TwoByTwoL,
            ThreeByThree,
            ThreeByThreeCross,
            ThreeByThreeL,
            ThreeByThreeS,
            ThreeByThreeT
        }

        // This is hilarious
        private readonly byte[][] _shape1By1 = new byte[][] { new byte[] { 1 } };
        private readonly byte[][] _shape2By1 = new byte[][] { new byte[] { 1, 1 } };
        private readonly byte[][] _shape2By2 = new byte[][]
        {
            new byte[] {1, 1},
            new byte[] {1, 1}
        };
        private readonly byte[][] _shape2By2L = new byte[][]
        {
            new byte[] {1, 0},
            new byte[] {1, 1}
        };
        private readonly byte[][] _shape3By3 = new byte[][]
        {
            new byte[] {1, 1, 1},
            new byte[] {1, 1, 1},
            new byte[] {1, 1, 1}
        };
        private readonly byte[][] _shape3By3L = new byte[][]
        {
            new byte[] {1, 0, 0},
            new byte[] {1, 0, 0},
            new byte[] {1, 1, 1}
        };
        private readonly byte[][] _shape3By3S = new byte[][]
        {
            new byte[] {0, 1, 1},
            new byte[] {0, 1, 0},
            new byte[] {1, 1, 0}
        };
        private readonly byte[][] _shape3By3T = new byte[][]
        {
            new byte[] {1, 1, 1},
            new byte[] {0, 1, 0},
            new byte[] {0, 1, 0}
        };
        
        [Tooltip("The shape of the tile.")]
        public TileShape shape = TileShape.OneByOne;
        
        [Tooltip("Whether the tile may spawn horizontally flipped.")]
        public bool canSpawnHorizontallyFlipped = true;
        
        [Tooltip("Whether the tile may spawn vertically flipped.")]
        public bool canSpawnVerticallyFlipped = true;

        /// <summary>
        /// The X position of the upper-left of the tile in the grid.
        /// </summary>
        public ushort positionX = 0;
        
        /// <summary>
        /// The Y position of the upper-left of the tile in the grid.
        /// </summary>
        public ushort positionY = 0;

        /// <summary>
        /// Whether the tile is horizontally flipped (Where x = -1 becomes x = 1).
        /// </summary>
        public bool horizontalFlip = false;
        
        /// <summary>
        /// Whether the tile is vertically flipped (Where y = -1 becomes y = 1).
        /// </summary>
        public bool verticalFlip = false;

        /// <summary>
        /// The rotation of the tile, multiplied by 90 degrees. IE, 2 = 180 degrees.
        /// </summary>
        public byte rotation = 0;
    }
}
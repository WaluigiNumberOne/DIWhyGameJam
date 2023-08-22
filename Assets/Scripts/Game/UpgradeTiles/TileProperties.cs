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
        private static readonly byte[][] Shape1By1 = new byte[][] { new byte[] { 1 } };
        private static readonly byte[][] Shape2By1 = new byte[][] { new byte[] { 1, 1 } };
        private static readonly byte[][] Shape2By2 = new byte[][]
        {
            new byte[] {1, 1},
            new byte[] {1, 1}
        };
        private static readonly byte[][] Shape2By2L = new byte[][]
        {
            new byte[] {1, 0},
            new byte[] {1, 1}
        };
        private static readonly byte[][] Shape3By3 = new byte[][]
        {
            new byte[] {1, 1, 1},
            new byte[] {1, 1, 1},
            new byte[] {1, 1, 1}
        };
        private static readonly byte[][] Shape3By3L = new byte[][]
        {
            new byte[] {1, 0, 0},
            new byte[] {1, 0, 0},
            new byte[] {1, 1, 1}
        };
        private static readonly byte[][] Shape3By3S = new byte[][]
        {
            new byte[] {0, 1, 1},
            new byte[] {0, 1, 0},
            new byte[] {1, 1, 0}
        };
        private static readonly byte[][] Shape3By3T = new byte[][]
        {
            new byte[] {1, 1, 1},
            new byte[] {0, 1, 0},
            new byte[] {0, 1, 0}
        };
        
        [Tooltip("The shape of the tile.")]
        public TileShape shape = TileShape.OneByOne;
        
        /// <summary>
        /// The 'physical' shape of the tile.
        /// This is only ever used when determining if the shape fits, or while placing the tile.
        /// </summary>
        public byte[][] PhysicalShape {
            get
            {
                switch (shape)
                {
                    case TileShape.TwoByOne: return Shape2By1;
                    case TileShape.TwoByTwo: return Shape2By2;
                    case TileShape.TwoByTwoL: return Shape2By2L;
                    case TileShape.ThreeByThree: return Shape3By3;
                    case TileShape.ThreeByThreeL: return Shape3By3L;
                    case TileShape.ThreeByThreeS: return Shape3By3S;
                    case TileShape.ThreeByThreeT: return Shape3By3T;
                    
                    default: return Shape1By1;
                }
            }
        }
        
        [Tooltip("Whether the tile may spawn horizontally flipped.")]
        public bool canSpawnHorizontallyFlipped = true;
        
        [Tooltip("Whether the tile may spawn vertically flipped.")]
        public bool canSpawnVerticallyFlipped = true;
        
        /// <summary>
        /// The tile id when this tile is added to a grid.
        /// </summary>
        public int tileId;

        /// <summary>
        /// The X position of the upper-left of the tile in the grid.
        /// </summary>
        public int positionX = 0;
        
        /// <summary>
        /// The Y position of the upper-left of the tile in the grid.
        /// </summary>
        public int positionY = 0;

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
using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Unity.FPS.Gameplay.UpgradeTiles
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
        
        [Tooltip("The shape of the tile.")]
        public TileShape shape = TileShape.OneByOne;
        
        [Tooltip("Whether the tile may spawn horizontally flipped.")]
        public bool canSpawnHorizontallyFlipped = true;
        
        [Tooltip("Whether the tile may spawn vertically flipped.")]
        public bool canSpawnVerticallyFlipped = true;

        /// <summary>
        /// The X position of the upper-left of the tile in the grid.
        /// </summary>
        [NonSerialized]
        public ushort PositionX = 0;
        
        /// <summary>
        /// The Y position of the upper-left of the tile in the grid.
        /// </summary>
        [NonSerialized]
        public ushort PositionY = 0;

        /// <summary>
        /// Whether the tile is horizontally flipped (Where x = -1 becomes x = 1).
        /// </summary>
        [NonSerialized]
        public bool HorizontalFlip = false;
        
        /// <summary>
        /// Whether the tile is vertically flipped (Where y = -1 becomes y = 1).
        /// </summary>
        [NonSerialized]
        public bool VerticalFlip = false;

        /// <summary>
        /// The rotation of the tile, multiplied by 90 degrees. IE, 2 = 180 degrees.
        /// </summary>
        [NonSerialized]
        public byte Rotation = 0;
    }
}
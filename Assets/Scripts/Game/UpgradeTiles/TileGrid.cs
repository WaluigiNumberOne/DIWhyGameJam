using System;
using UnityEngine;

namespace Unity.FPS.Game.UpgradeTiles
{
    public class TileGrid : MonoBehaviour
    {
        // This may seem really bad. And you're right! It is!
        // 0s are used to designate spots where you may place a tile.
        // -1s are used to designate spots where no tile may be placed.
        private readonly short[][] _gridTest =
        {
            new short[]{0, 0, 0, 0},
            new short[]{0, 0, -1, 0},
            new short[]{0, 0, 0, 0},
            new short[]{0, 0, 0, 0}
        };

        public enum GridShape
        {
            Test
        }

        /// <summary>
        /// This is the abstracted 'shape' of the grid.
        /// </summary>
        public GridShape shape;

        /// <summary>
        /// The 'physical' grid. Used to determine whether positions are free or occupied.
        /// </summary>
        private short[][] _grid;

        private void Awake()
        {
            switch (shape)
            {
                case GridShape.Test:
                    _grid = _gridTest;
                    break;
            }
        }

        /// <summary>
        /// Returns whether the given shape can fit at the given position within the grid.
        /// </summary>
        /// <param name="shape"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>True when the given shape can fit. False when there is an intersection.</returns>
        public bool TileFits(short[][] shape, short x, short y)
        {
            // Keep the shape within the bounds
            if (x < 0 || y < 0) return false;

            if (x + shape.Length > _grid.Length || y + shape[0].Length > _grid[0].Length) return false;

            for (int scanX = 0; scanX < shape.Length; scanX++)
            {
                for (int scanY = 0; scanY < shape[0].Length; scanY++)
                {
                    if (shape[scanX][scanY] == 0) continue; // Blank part of the shape, skip this
                    if (_grid[x + scanX][y + scanY] != 0) return false; // Intersection! Failed :(
                }
            }
            
            return true;
        }
    }
}
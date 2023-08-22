using System;
using System.Text;
using UnityEngine;

namespace Unity.FPS.Game.UpgradeTiles
{
    public class TileGrid : MonoBehaviour
    {
        // This may seem really bad. And you're right! It is!
        // 0s are used to designate spots where you may place a tile.
        // -1s are used to designate spots where no tile may be placed.
        private static readonly int[][] GridTest =
        {
            new []{0, 0, 0, 0},
            new []{0, 0, -1, 0},
            new []{0, 0, 0, 0},
            new []{0, 0, 0, 0}
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
        /// Reading and writing from this grid should be done as _grid[Y][X].
        /// </summary>
        private int[][] _grid;

        /// <summary>
        /// Determines with tile ids are available for use. Since gameObjects can be in any arbitrary order.
        /// Dislike it, but whatever.
        /// </summary>
        private bool[] _idUsage = new bool[128];

        private void Awake()
        {
            switch (shape)
            {
                case GridShape.Test:
                    _grid = GridTest;
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
        public bool TileFits(byte[][] shape, int x, int y)
        {
            // Keep the shape within the bounds
            if (x < 0 || y < 0) return false;

            if (x + shape.Length > _grid.Length || y + shape[0].Length > _grid[0].Length) return false;

            for (int scanX = 0; scanX < shape.Length; scanX++)
            {
                for (int scanY = 0; scanY < shape[0].Length; scanY++)
                {
                    if (shape[scanX][scanY] == 0) continue; // Blank part of the shape, skip this
                    if (_grid[y + scanY][x + scanX] != 0) return false; // Intersection! Failed :(
                }
            }
            
            return true;
        }

        /// <summary>
        /// Removes a tile from the grid by tile id.
        /// This will not unparent the object, so make sure you do that yourself.
        /// </summary>
        /// <param name="tileId">The tile id to remove</param>
        public void RemoveTile(short tileId)
        {
            for (int x = 0; x < _grid.Length; x++)
            {
                for (int y = 0; y < _grid[0].Length; y++)
                {
                    if (_grid[x][y] == tileId)
                        _grid[x][y] = 0; // Clear the tile position
                }
            }

            SetTileIdUsage(tileId, false);
        }

        /// <summary>
        /// Adds a tile to the grid. Pass in the TileProperties attached to the gameObject, this should handle
        /// the rest.
        /// </summary>
        /// <param name="tileProperties"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool AddTile(TileProperties tileProperties, int x, int y)
        {
            int tileId = 0;
            if (!FindUnusedTileId(ref tileId))
                return false; // No available tile id, so fail
            
            byte[][] shape = tileProperties.PhysicalShape;

            // Make sure the tile fits
            if (!TileFits(shape, x, y))
                return false;

            // Set the tile id
            for (int scanX = 0; scanX < shape.Length; scanX++)
            {
                for (int scanY = 0; scanY < shape[0].Length; scanY++)
                {
                    _grid[y + scanY][x + scanX] = tileId;
                }
            }
            
            Debug.Log(ToString());
            
            // Re-parent the tile object
            tileProperties.gameObject.transform.SetParent(gameObject.transform);
            tileProperties.tileId = (short) tileId;

            tileProperties.positionX = x;
            tileProperties.positionY = y;

            SetTileIdUsage(tileId, true);

            return true;
        }

        /// <summary>
        /// Sets the input 'id' to the first unoccupied tile id.
        /// Returns whether an id could be found.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Whether a free id could be found</returns>
        public bool FindUnusedTileId(ref int id)
        {
            for (int i = 0; i < _idUsage.Length; i++)
            {
                if (!_idUsage[i])
                {
                    id = i + 1;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Because id '0' is considered a blank square in the tile grid, tile ids are stored in individual tile objects
        /// in a 1-indexed fashion (id 0 in this array corresponds to id 1 in the gameObject).
        /// This will remove confusion when working with setting tile ids.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="used"></param>
        public void SetTileIdUsage(int id, bool used)
        {
            _idUsage[id - 1] = used;
        }

        /// <summary>
        /// Calculate stats based on the tiles in this grid.
        /// </summary>
        /// <param name="baseStats"></param>
        /// <returns></returns>
        public GunStats CalculateStats(GunStats baseStats)
        {
            GunStats newStats = (GunStats)baseStats.Clone();
            
            foreach (IUpgradeTile tile in gameObject.GetComponentsInChildren<IUpgradeTile>())
                tile.ApplyStats(newStats);
            
            return newStats.Normalise();
        }

        public override string ToString()
        {
            StringBuilder builder = new();

            for (int x = 0; x < _grid.Length; x++)
            {
                for (int y = 0; y < _grid[0].Length; y++)
                {
                    builder.Append(_grid[x][y] == 0 ? '0' : 'X');
                }

                builder.Append('\n');
            }

            return builder.ToString();
        }
    }
}
using Unity.FPS.Game;
using UnityEngine;

namespace Unity.FPS.Game.UpgradeTiles
{
    public interface IUpgradeTile
    {
        /// <summary>
        /// Applies this tile's stat changes to the passed GunStats.
        /// </summary>
        /// <param name="stats"></param>
        public void ApplyStats(GunStats stats);
    }
}
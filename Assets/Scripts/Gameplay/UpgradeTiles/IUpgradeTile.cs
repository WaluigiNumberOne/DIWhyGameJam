using UnityEngine;

namespace Unity.FPS.Gameplay.UpgradeTiles
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
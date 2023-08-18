using System;
using Unity.FPS.Game;
using UnityEngine;
using UnityEngine.Serialization;

namespace Unity.FPS.Game.UpgradeTiles
{
    /// <summary>
    /// Increases one stat on the given weapon by a fixed amount.
    /// </summary>
    public class StatUpgradeTile : MonoBehaviour, IUpgradeTile
    {
        public enum Type
        {
            None,
            ProjectilesPerShot,
            FireTime,
            Damage,
            ReloadTime,
            Spread,
            ClipSize,
            Recoil
        }

        [Tooltip("Type of upgrade")]
        public Type upgradeType = Type.None;
        
        [Tooltip("The amount to increase by. Can be negative. Floored for integer-only stats (IE, Barrels).")]
        public float amount = 0.0f;
        
        public void ApplyStats(GunStats stats)
        {
            switch (upgradeType)
            {
                case Type.None:
                    break;
                case Type.ProjectilesPerShot:
                    stats.projectilesPerShot += (int)amount;
                    stats.ammoCostPerShot += (int)amount;
                    break;
                case Type.FireTime:
                    stats.shotCooldownSeconds += amount;
                    break;
                case Type.Damage:
                    stats.damage += (int) amount;
                    break;
                case Type.ReloadTime:
                    stats.reloadTimeSeconds += amount;
                    break;
                case Type.Spread:
                    stats.spreadRadians += amount;
                    break;
                case Type.ClipSize:
                    stats.clipSize += (int) amount;
                    break;
                case Type.Recoil:
                    stats.recoilRadians += amount;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
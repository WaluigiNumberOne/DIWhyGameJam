using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Unity.FPS.Gameplay.UpgradeTiles
{
    /// <summary>
    /// Increases one stat on the given weapon by a fixed amount.
    /// </summary>
    public class StatUpgradeTile : MonoBehaviour, IUpgradeTile
    {
        public enum Type
        {
            None,
            Barrels,
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
                case Type.Barrels:
                    stats.BarrelCount += (int) amount;
                    break;
                case Type.FireTime:
                    stats.ShotCooldownSeconds += amount;
                    break;
                case Type.Damage:
                    stats.Damage += (int) amount;
                    break;
                case Type.ReloadTime:
                    stats.ReloadTimeSeconds += amount;
                    break;
                case Type.Spread:
                    stats.SpreadRadians += amount;
                    break;
                case Type.ClipSize:
                    stats.ClipSize += (int) amount;
                    break;
                case Type.Recoil:
                    stats.RecoilRadians += amount;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
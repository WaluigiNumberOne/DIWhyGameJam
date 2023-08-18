using System;

namespace Unity.FPS.Game
{
    [Serializable]
    public class GunStats : ICloneable
    {
        /// <summary>
        /// The number of projectiles created by this gun when it is fired.
        ///
        /// This value will be normalised to 0 if less than 0.
        /// </summary>
        public int projectilesPerShot = 1;

        /// <summary>
        /// The amount of ammo deducted from the clip every time the weapon is shot.
        ///
        /// This value will be normalised to 0 if less than 0.
        /// </summary>
        public int ammoCostPerShot = 1;

        /// <summary>
        /// The number of seconds the user must wait after shooting before the gun can be fired again.
        /// This is essentially "fire rate", lower it to make the gun shoot faster.
        ///
        /// This value will be normalised to 0 if less than 0.
        /// </summary>
        public float shotCooldownSeconds = 0.2f;

        /// <summary>
        /// How much damage the projectiles created by this gun will deal upon impact with an entity.
        ///
        /// Negative values will heal the hit target.
        /// </summary>
        public int damage = 5;

        /// <summary>
        /// The number of seconds it takes to reload this weapon.
        ///
        /// This value will be normalised to 0 if less than 0.
        /// </summary>
        public float reloadTimeSeconds = 1.0f;

        /// <summary>
        /// The angle, in radians, added to the firing direction of this gun when a bullet is to be spawned.
        /// This is essentially the inverse of "accuracy", lower it to make the gun's spread tighter.
        ///
        /// This value will be normalised to 0 if less than 0.
        /// </summary>
        public float spreadRadians = 0.392f;

        /// <summary>
        /// The number of bullets this gun can fire before needing to reload.
        ///
        /// This value will be normalised to 1 if less than 1.
        /// </summary>
        public int clipSize = 16;

        /// <summary>
        /// The angle, in radians, that the player's view will be jerked by when this weapon is fired.
        ///
        /// This value will be normalised to 0 if less than 0.
        /// </summary>
        public float recoilRadians = 0.392f;

        /// <summary>
        /// Normalise all stats. This should be called as the stats are cached.
        /// </summary>
        public GunStats Normalise()
        {
            projectilesPerShot = Math.Max(1, projectilesPerShot);
            shotCooldownSeconds = Math.Max(0, shotCooldownSeconds);
            reloadTimeSeconds = Math.Max(0, reloadTimeSeconds);
            spreadRadians = Math.Max(0, spreadRadians);
            clipSize = Math.Max(1, clipSize);
            recoilRadians = Math.Max(0, recoilRadians);

            return this;
        }
        
        public object Clone()
        {
            GunStats clone = new()
            {
                projectilesPerShot = projectilesPerShot,
                shotCooldownSeconds = shotCooldownSeconds,
                damage = damage,
                reloadTimeSeconds = reloadTimeSeconds,
                spreadRadians = spreadRadians,
                clipSize = clipSize,
                recoilRadians = recoilRadians
            };

            return clone;
        }
    }
}
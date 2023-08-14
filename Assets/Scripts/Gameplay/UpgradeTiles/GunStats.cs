namespace Unity.FPS.Gameplay.UpgradeTiles
{
    public class GunStats
    {
        /// <summary>
        /// The number of barrels attached to this gun. For right now, this is equal to the number of projectiles
        /// created when the gun is fired.
        ///
        /// This value will be normalised to 0 if less than 0.
        /// </summary>
        public int BarrelCount = 1;

        /// <summary>
        /// The number of seconds the user must wait after shooting before the gun can be fired again.
        /// This is essentially "fire rate", lower it to make the gun shoot faster.
        ///
        /// This value will be normalised to 0 if less than 0.
        /// </summary>
        public float ShotCooldownSeconds = 1.0f;

        /// <summary>
        /// How much damage the projectiles created by this gun will deal upon impact with an entity.
        ///
        /// Negative values will heal the hit target.
        /// </summary>
        public int Damage = 5;

        /// <summary>
        /// The number of seconds it takes to reload this weapon.
        ///
        /// This value will be normalised to 0 if less than 0.
        /// </summary>
        public float ReloadTimeSeconds = 1.0f;

        /// <summary>
        /// The angle, in radians, added to the firing direction of this gun when a bullet is to be spawned.
        /// This is essentially the inverse of "accuracy", lower it to make the gun's spread tighter.
        ///
        /// This value will be normalised to 0 if less than 0.
        /// </summary>
        public float SpreadRadians = 2.0f;

        /// <summary>
        /// The number of bullets this gun can fire before needing to reload.
        ///
        /// This value will be normalised to 0 if less than 0.
        /// </summary>
        public int ClipSize = 16;

        /// <summary>
        /// The angle, in radians, that the player's view will be jerked by when this weapon is fired.
        ///
        /// This value will be normalised to 0 if less than 0.
        /// </summary>
        public float RecoilRadians = 1.0f;
    }
}
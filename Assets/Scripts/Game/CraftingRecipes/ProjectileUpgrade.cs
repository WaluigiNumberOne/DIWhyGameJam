using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileUpgrade : CraftingRecipe
{
    void Awake()
    {
        craftableObj = Resources.Load("Craftables/ProjectileUpgrade");
        name = "Projectile Upgrade";
        description = "Shoot more projectiles out of your gun with every shot";

        components = new List<Vector2>();

        components.Add(new Vector2(0, 1));  // 1 duct tape
        components.Add(new Vector2(1, 1));  // 2 metal
    }

}

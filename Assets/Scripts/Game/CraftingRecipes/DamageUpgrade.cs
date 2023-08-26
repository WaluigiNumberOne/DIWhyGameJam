using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUpgrade : CraftingRecipe
{
    void Awake()
    {
        craftableObj = Resources.Load("Craftables/DamageUpgrade");
        name = "Damage Upgrade";
        description = "Bullets do more damage";

        components = new List<Vector2>();

        components.Add(new Vector2(0, 1));  // 1 duct tape
        components.Add(new Vector2(2, 1));  // 1 wire
    }

}

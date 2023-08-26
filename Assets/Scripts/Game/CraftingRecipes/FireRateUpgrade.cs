using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRateUpgrade : CraftingRecipe
{
    void Awake()
    {
        craftableObj = Resources.Load("Craftables/FireRateUpgrade.prefab");
        name = "Fire Rate Upgrade";
        description = "Shoot faster";

        components = new List<Vector2>();

        components.Add(new Vector2(0, 1));  // 1 duct tape
        components.Add(new Vector2(3, 1));  // 1 spring
    }

}

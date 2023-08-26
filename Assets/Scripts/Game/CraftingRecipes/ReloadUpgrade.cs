using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadUpgrade : CraftingRecipe
{
    void Awake()
    {
        craftableObj = Resources.Load("Craftables/ReloadUpgrade");
        name = "Reload Upgrade";
        description = "Reload faster";

        components = new List<Vector2>();

        components.Add(new Vector2(0, 1));  // 1 duct tape
        components.Add(new Vector2(4, 1));  // 1 battery
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagazineSizeUpgrade : CraftingRecipe
{
    void Awake()
    {
        craftableObj = Resources.Load("Craftables/MagSizeUpgrade");
        name = "Mag Size Upgrade";
        description = "Shoot more bullets before reloading";

        components = new List<Vector2>();

        components.Add(new Vector2(0, 2));  // 2 duct tape
    }

}

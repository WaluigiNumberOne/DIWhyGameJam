using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccuracyUpgrade : CraftingRecipe
{
    void Awake()
    {
        craftableObj = Resources.Load("Craftables/AccuracyUpgrade");
        name = "Accuracy Upgrade";
        description = "Improves Accurracy by reducing spread";

        components = new List<Vector2>();

        components.Add(new Vector2(0, 1));  // 1 duct tape
        components.Add(new Vector2(1, 1));  // 1 Metal
    }

}

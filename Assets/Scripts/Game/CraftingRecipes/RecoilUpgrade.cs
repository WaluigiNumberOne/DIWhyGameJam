using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoilUpgrade : CraftingRecipe
{
    void Awake()
    {
        craftableObj = Resources.Load("Craftables/RecoilUpgrade");
        name = "Recoil Upgrade";
        description = "Handle the kick a little better";

        components = new List<Vector2>();

        components.Add(new Vector2(0, 1));  // 1 duct tape
        components.Add(new Vector2(3, 2));  // 2 spring
    }

}

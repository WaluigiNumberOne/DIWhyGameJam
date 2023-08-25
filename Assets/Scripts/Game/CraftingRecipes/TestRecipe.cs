using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRecipe : CraftingRecipe
{
    void Awake()
    {
        craftableObj = Resources.Load("Craftables/TestObject");
        name = "Big Ol Dingus";
        description = "World's Largest Dingus, 2015";

        components = new List<Vector2>();

        components.Add(new Vector2(0, 1));  // 1 duct tape
    }

}

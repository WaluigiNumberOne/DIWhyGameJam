using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2Recipe : CraftingRecipe
{
    void Awake()
    {
        craftableObj = Resources.Load("Craftables/TestObject");
        name = "Gun but larger";
        description = "make it big";

        components = new List<Vector2>();

        components.Add(new Vector2(0, 1));  // 1 duct tape
        components.Add(new Vector2(3, 2));  // 2 springs
        components.Add(new Vector2(4, 1));  // 1 battery
    }
}

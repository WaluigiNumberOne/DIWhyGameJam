using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CraftingManager : MonoBehaviour
{
    public bool setMenuActive = false;

    public List<CraftingRecipe> recipes;
    public string[] names;
    public int[] inventory;
    //Duct Tape -> 0
    //Metal -> 1
    //Wire -> 2
    //Spring -> 3
    //Battery -> 4

    // Start is called before the first frame update
    void Start()
    {
        initializeRecipes();

        inventory = new int[5];
        names = new string[]{"Duct Tape", "Scrap Metal", "Copper Wire", "Spring", "Battery"};
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void add(int type, int size)
    {
        inventory[type] += size;
    }

    public void displayInventory()
    {
        for(int i = 0; i <= 4; i++)
        {
            Debug.Log(names[i] + ": " + inventory[i]);
        }
    }

    public void OpenCraftingMenu()
    {
        setMenuActive = true;
    }

    public void initializeRecipes()
    {
        TestRecipe test = gameObject.AddComponent<TestRecipe>();
        Test2Recipe test2 = gameObject.AddComponent<Test2Recipe>();

        recipes.Add(test);
        recipes.Add(test2);
    }

    public List<CraftingRecipe> getRecipes()
    {
        return recipes;
    }
}

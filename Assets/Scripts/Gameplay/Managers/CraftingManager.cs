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
        AccuracyUpgrade accUp = gameObject.AddComponent<AccuracyUpgrade>();
        DamageUpgrade damageUp = gameObject.AddComponent<DamageUpgrade>();
        FireRateUpgrade rateUp = gameObject.AddComponent<FireRateUpgrade>();
        MagazineSizeUpgrade magUp = gameObject.AddComponent<MagazineSizeUpgrade>();
        ProjectileUpgrade projUp = gameObject.AddComponent<ProjectileUpgrade>();
        RecoilUpgrade recoilUp = gameObject.AddComponent<RecoilUpgrade>();
        ReloadUpgrade reloadUp = gameObject.AddComponent<ReloadUpgrade>();

        recipes.Add(accUp);
        recipes.Add(damageUp);
        recipes.Add(rateUp);
        recipes.Add(magUp);
        recipes.Add(projUp);
        recipes.Add(recoilUp);
        recipes.Add(reloadUp);

    }

    public List<CraftingRecipe> getRecipes()
    {
        return recipes;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    string[] names;
    int[] inventory;
    //Duct Tape -> 0
    //Metal -> 1
    //Wire -> 2
    //Spring -> 3
    //Battery -> 4

    // Start is called before the first frame update
    void Start()
    {
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

    }
}

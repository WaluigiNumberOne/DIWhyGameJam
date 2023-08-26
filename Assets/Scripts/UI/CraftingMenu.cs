using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.FPS.UI;
using TMPro;
using System;

public class CraftingMenu : MonoBehaviour
{
    public GameObject MenuRoot;
    public Button closeMenu;
    public TMP_Text tapeText;
    public TMP_Text metalText;
    public TMP_Text wireText;
    public TMP_Text springText;
    public TMP_Text batteryText;

    public GameObject recipeDisplayPrefab;
    public Transform recipeRoot;
    public TMP_Text descText;
    public Scrollbar scrollbar;

    CraftingManager craftingManager;
    public CraftingRecipe activeRecipe;

    string missingComponent;

    // Start is called before the first frame update
    void Start()
    {
        craftingManager = FindObjectOfType<CraftingManager>();

        InstantiateRecipePrefabs();
    }

    // Update is called once per frame
    void Update()
    {
        if(craftingManager.setMenuActive)
        {
            SetMenuActive(true);
            craftingManager.setMenuActive = false;
        }
    }

    public void SetMenuActive(bool active)
    {
        MenuRoot.SetActive(active);
        //Debug.Log("Crafting Menu: " + active);

        UpdateInventoryUI();

        if (MenuRoot.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;

            EventSystem.current.SetSelectedGameObject(null);
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1f;
        }

        
    }

    public void SelectRecipe(RecipeDisplay display)
    {
        display.show();
        activeRecipe = display.GetRecipe();
    }

    public void tryCraftActiveRecipe()
    {
        //Debug.Log("Active Recipe: " + activeRecipe.name);
        if (checkComponents())
        {
            //Debug.Log("Crafting...");
            if (activeRecipe != null)
            {
                Instantiate(activeRecipe.craftableObj);
                foreach (Vector2 v in activeRecipe.components)
                {
                    craftingManager.inventory[(int)v.x] -= (int)v.y;        //Take components out of inventory
                }
                UpdateInventoryUI();
            }
            else
                Debug.Log("well thats not good");
            
        }
        else
        {
            Debug.Log("Not Enough Components: " + missingComponent);
        }
    }

    private bool checkComponents()
    {
        foreach(Vector2 v in activeRecipe.components)
        {
            if (v.y > craftingManager.inventory[(int)v.x])  //Dont Have Enough Components
            {
                missingComponent = v.x.ToString();
                return false;
            }
        }
        return true;
    }

    private void InstantiateRecipePrefabs()
    {
        int recipeNum = 0;
        List<CraftingRecipe> recipes = craftingManager.getRecipes();

        foreach(CraftingRecipe c in recipes)
        {
            RecipeDisplay display = Instantiate(recipeDisplayPrefab, recipeRoot).GetComponent<RecipeDisplay>();
            display.GetComponentInChildren<Canvas>().transform.localScale = Vector3.one;                        //IDK why but it sets scale to 0 so fix that here
            display.transform.localPosition += Vector3.down * 110 * recipeNum;                                  //move down 110 pixels each time
            display.description = descText;
            display.scrollbar = scrollbar;
            display.SetRecipe(c);

            SelectRecipe(display);  //set active recipe to most recent

            recipeNum++;
        }

        
    }

    private void UpdateInventoryUI()
    {
        tapeText.text = "X " + craftingManager.inventory[0];
        metalText.text = "X " + craftingManager.inventory[1];
        wireText.text = "X " + craftingManager.inventory[2];
        springText.text = "X " + craftingManager.inventory[3];
        batteryText.text = "X " + craftingManager.inventory[4];
    }

    public void close()
    {
        SetMenuActive(false);
    }
}

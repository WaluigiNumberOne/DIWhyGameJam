using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecipeDisplay : MonoBehaviour
{
    public TMP_Text name;
    public TMP_Text description;
    public TMP_Text components;
    public Button selectButton;

    public CraftingRecipe craftingRecipe;

    public void SetRecipe(CraftingRecipe recipe)
    {
        craftingRecipe = recipe;
        //Debug.Log(craftingRecipe);
        name.text = recipe.name;
        description.text = recipe.description;
        components.text = recipe.getComponentsAsString();
    }

    public void show()
    {
        description.text = craftingRecipe.description;
    }

    public CraftingRecipe GetRecipe()
    {
        return craftingRecipe;
    }

    public void onButtonClick()
    {
        FindObjectOfType<CraftingMenu>().SelectRecipe(this);
    }

}

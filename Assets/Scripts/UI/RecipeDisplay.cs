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
    public Scrollbar scrollbar;
    public float offset = 660f;
    public float startingY;

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

    private void Update()
    {
        transform.localPosition = new Vector2(transform.localPosition.x, startingY + offset * scrollbar.value);
    }

    private void Start()
    {
        offset = 660;   //100 bucks to whoever can figue out why it keeps getting set to 200 instead of the initialized value (200 was the first value i tried)
        startingY = transform.localPosition.y;
    }

}

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

    CraftingManager craftingManager;

    // Start is called before the first frame update
    void Start()
    {
        craftingManager = FindObjectOfType<CraftingManager>();
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
        Debug.Log("Crafting Menu: " + active);

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.FPS.UI;
using System;

public class CraftingMenu : MonoBehaviour
{
    public GameObject MenuRoot;
    public Button closeMenu;

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

    public void close()
    {
        SetMenuActive(false);
    }
}

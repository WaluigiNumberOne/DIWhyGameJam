using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Gameplay;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
    PlayerInputHandler m_Input;

    public GameObject MenuRoot;
    public GameObject inventoryPanel;
    public Button closeMenu;
    // Start is called before the first frame update
    void Start()
    {
        m_Input = FindObjectOfType<PlayerInputHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Input.GetUpgradeMenuInput())
        {
            SetMenuActive(!MenuRoot.activeSelf);    //open if closed, close if opened
        }
    }

    public void SetMenuActive(bool active)
    {
        MenuRoot.SetActive(active);
        //Debug.Log("Crafting Menu: " + active);

        //UpdateUpgradeTilesUI();

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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UpgradeTile : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Canvas parentCanvas;

    bool followingMouse = false;

    GraphicRaycaster caster;
    EventSystem m_EventSystem;
    PointerEventData m_PointerEventData;

    // Start is called before the first frame update
    void Start()
    {
        m_EventSystem = FindObjectOfType<EventSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(followingMouse)
        {
            followMouse();
        }
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("clicked");
        caster = parentCanvas.GetComponent<GraphicRaycaster>();
        m_PointerEventData = new PointerEventData(m_EventSystem);
        m_PointerEventData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();
        caster.Raycast(m_PointerEventData, results);

        UIUpgradeSlot slot = null;
        foreach (RaycastResult r in results)
        {
            if (r.gameObject.GetComponent<UIUpgradeSlot>())
            {
                slot = r.gameObject.GetComponent<UIUpgradeSlot>();
                slot.removeTile();
                break;
            }

        }


        followingMouse = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //Debug.Log("released");
        caster = parentCanvas.GetComponent<GraphicRaycaster>();
        m_PointerEventData = new PointerEventData(m_EventSystem);
        m_PointerEventData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();
        caster.Raycast(m_PointerEventData, results);

        bool foundSlot = false;
        UIUpgradeSlot slot = null;
        foreach(RaycastResult r in results)
        {
            if(r.gameObject.GetComponent<UIUpgradeSlot>())
            {
                slot = r.gameObject.GetComponent<UIUpgradeSlot>();
                foundSlot = true;
            }
            
        }

        if (foundSlot)
        {
            if (!slot.Assign(this))
            {
                //reset
                Debug.Log("Slot is taken");
                transform.SetParent(FindObjectOfType<UpgradeTileManager>().transform);
            }
        }
        else
        {
            transform.SetParent(FindObjectOfType<UpgradeTileManager>().transform);
        }
        //Re-sort tiles
        FindObjectOfType<UpgradeTileManager>().SortAll();
        followingMouse = false;
    }

    void followMouse()
    {
        Vector2 movePos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)parentCanvas.transform, Input.mousePosition, parentCanvas.worldCamera, out movePos);

        transform.position = parentCanvas.transform.TransformPoint(movePos);
    }
}

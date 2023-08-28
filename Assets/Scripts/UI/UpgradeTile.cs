using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpgradeTile : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Canvas parentCanvas;

    bool followingMouse = false;

    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        
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
        Debug.Log("clicked");
        startPos = transform.localPosition;
        followingMouse = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("released");
        transform.localPosition = startPos;
        followingMouse = false;
    }

    void followMouse()
    {
        Vector2 movePos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)parentCanvas.transform, Input.mousePosition, parentCanvas.worldCamera, out movePos);

        Debug.Log(movePos);
        transform.position = parentCanvas.transform.TransformPoint(movePos);
    }
}

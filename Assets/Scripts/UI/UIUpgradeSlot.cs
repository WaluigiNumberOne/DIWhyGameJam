using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIUpgradeSlot : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("clicked over slot");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //Debug.Log("released over slot");
    }

    public void Assign(UpgradeTile ut)
    {
        ut.transform.parent = transform;
        ut.transform.localPosition = Vector3.zero;
    }

}

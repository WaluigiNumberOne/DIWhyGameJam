using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Game.UpgradeTiles;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIUpgradeSlot : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    UpgradeTile tileCopy;

    public TileGrid tg;

    // Start is called before the first frame update
    void Start()
    {
        tg = FindObjectOfType<TileGrid>();
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

    public bool Assign(UpgradeTile ut)
    {
        //Put Duplicate Tile Onto tile Grid
        tileCopy = Instantiate(ut);
        TileProperties tileProp = tileCopy.GetComponent<TileProperties>();

        string xy = transform.name.Substring(transform.name.Length - 2);
        
        int x = int.Parse(xy.Substring(0,1)) - 1;       //1st letter
        int y = int.Parse(xy.Substring(1))  - 1;         //2nd letter

        if (tg.AddTile(tileProp, y, x))
        {
            //success
            ut.transform.parent = transform;
            ut.transform.localPosition = Vector3.zero;
            Debug.Log("added");
            return true;
            

        }
        else
        {
            Destroy(tileCopy.gameObject);
        }
        return false;

        
    }

    public void removeTile()
    {
        int tileID = tileCopy.GetComponent<TileProperties>().tileId;

        tg.RemoveTile((short) tileID);

        Destroy(tileCopy.gameObject);
    }

}

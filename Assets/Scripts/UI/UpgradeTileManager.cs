using System;
using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Game.UpgradeTiles;
using UnityEngine;


public class UpgradeTileManager : MonoBehaviour
{
    float TILE_OFFSET_X = 30;
    float TILE_OFFSET_Y = -30;

    List<IUpgradeTile> tileList;


    public GameObject tileSortRoot;
    // Start is called before the first frame update
    void Start()
    {
        tileList = new List<IUpgradeTile>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount > 0)  // new upgrades to sort
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                SortChild(transform.GetChild(i));
            }
        }
    }

    private void SortChild(Transform child)
    {  
        float x = tileSortRoot.transform.childCount * TILE_OFFSET_X;
        float y = 0;
        if(tileSortRoot.transform.childCount >= 11)
        { 
            if(tileSortRoot.transform.childCount > 22)
            {
                throw new NotImplementedException();
            }
            y = TILE_OFFSET_Y;
            x = (tileSortRoot.transform.childCount - 11) * TILE_OFFSET_X;
        }

        tileList.Add(child.GetComponent<IUpgradeTile>());
        child.GetComponent<UpgradeTile>().parentCanvas = transform.parent.parent.GetComponent<Canvas>();

        child.SetParent(tileSortRoot.transform);
        child.localPosition = new Vector2(x, y);
    }

}

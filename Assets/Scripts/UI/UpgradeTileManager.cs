using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTileManager : MonoBehaviour
{
    float TILE_OFFSET_X = 30;
    float TILE_OFFSET_Y = -30;


    public GameObject tileSortRoot;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount > 0)  // new upgrades to sort
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

        child.SetParent(tileSortRoot.transform);
        child.localPosition = new Vector2(x, y);
    }
}

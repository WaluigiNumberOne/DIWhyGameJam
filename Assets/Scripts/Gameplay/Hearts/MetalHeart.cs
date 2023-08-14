using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalHeart : Heart
{
    bool oneWayFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (conditions())
        {
            effects();
        }
    }

    public override void effects()
    {
        if(!oneWayFlag)
        {
            oneWayFlag = true;
            hp = 2;
            //Debug.Log("Metal Heart HP set to 2");
        }
    }

    public override bool conditions()
    {
        return active;
    }
}

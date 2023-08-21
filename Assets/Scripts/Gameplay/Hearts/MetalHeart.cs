using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalHeart : Heart
{
    bool oneWayFlag = false;

    // Start is called before the first frame update
    void Awake()
    {
        type = 3;
        spr = setSprite();
        effects();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public override void onLoseHeart()
    {
        //Do nothing
    }

    public override void effects()
    {
        //Effect triggers on pickup
        if(!oneWayFlag)
        {
            oneWayFlag = true;
            hp = 2;
            //Debug.Log("Metal Heart HP set to 2");
        }
    }

    public override bool conditions()
    {
        //if this is the active heart, trigger effect
        return active;
    }

    public override Sprite setSprite()
    {
        var sprite = Resources.Load<Sprite>("PlaceholderMetalHeart");
        return sprite;
    }
}

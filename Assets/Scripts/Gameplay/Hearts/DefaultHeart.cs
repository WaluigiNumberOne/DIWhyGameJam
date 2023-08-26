using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultHeart : Heart
{
    
    // Start is called before the first frame update
    void Awake()
    {
        type = 0;
        spr = setSprite();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void onLoseHeart()
    { 
    
    }

    public override void effects()
    {
        //Do nothing
    }

    public override bool conditions()
    {
        return false;
    }

    public override Sprite setSprite()
    {
        var sprite = Resources.Load<Sprite>("default");
        return sprite;
    }
}

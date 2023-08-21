using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyHeart : Heart
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerHeartManager phm = FindObjectOfType<PlayerHeartManager>();
        //second to last heart
        phm.AddHeart(phm.hearts[phm.hearts.Count - 2].type);
        phm.hearts.Remove(this);
        Destroy(this);
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
        var sprite = Resources.Load<Sprite>("var2");
        return sprite;
    }
}

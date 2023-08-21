using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechargeableHeart : Heart
{
    bool oneWayFlag = false;
    bool damaged = false;
    float damagedTime = 0;
    float TIME_UNTIL_REGEN = 5f;

    // Start is called before the first frame update
    void Awake()
    {
        spr = setSprite();
        effects();
    }

    // Update is called once per frame
    void Update()
    {
        if(hp < 2 && !damaged)
        {
            damaged = true;
            damagedTime = 0;
        }

        if(damaged)
        {
            damagedTime += Time.deltaTime;
            Debug.Log(damagedTime);
        }

        if(damagedTime >= TIME_UNTIL_REGEN)
        {
            damagedTime = 0;
            damaged = false;
            hp = 2;
        }
    }

    public override void onLoseHeart()
    {
        //Do nothing
    }

    public override void effects()
    {
        //Effect triggers on pickup
        if (!oneWayFlag)
        {
            oneWayFlag = true;
            hp = 2;
            //Debug.Log("Rechargeable Heart HP set to 2");
        }

    }

    public override bool conditions()
    {
        //if this is the active heart, trigger effect
        return active;
    }

    public override Sprite setSprite()
    {
        var sprite = Resources.Load<Sprite>("PlaceholderRegenHeart");
        return sprite;
    }
}

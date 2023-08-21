using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Heart : MonoBehaviour
{
    //0 ->  default heart
    //1 ->  speed heart
    //2 ->  jump heart
    //3 ->  metal heart
    //4 ->  bomb heart
    //5 ->  copy heart                  DOES NOT HAVE ACTIVE TYPE BECAUSE IT JUST COPIES A DIFFERENT ONE
    //6 ->  rechargeable heart

    public int type = 0;

    public float hp = 1;
    public bool active = false;
    public Sprite spr;

    public abstract void effects();
    public abstract bool conditions();
    public abstract Sprite setSprite();

    public abstract void onLoseHeart();
}

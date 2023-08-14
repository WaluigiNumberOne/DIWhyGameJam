using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Heart : MonoBehaviour
{
    public float hp = 1;
    public bool active = false;
    public Sprite spr;

    public abstract void effects();
    public abstract bool conditions();
    public abstract Sprite setSprite();

    public abstract void onLoseHeart();
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombHeart : Heart
{
    Explosion explosionPrefab;

    // Start is called before the first frame update
    void Awake()
    {
        spr = setSprite();
        explosionPrefab = Resources.Load<Explosion>("Explosion");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void onLoseHeart()
    {
        Debug.Log("Bomb Heart Explosion");

        //Create an explostion prefab at the center of the player
        Transform explosion = Instantiate(explosionPrefab).transform;
        explosion.SetParent(FindObjectOfType<PlayerHeartManager>().transform);
        explosion.localPosition = Vector3.zero + (Vector3.up * .5f);
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
        var sprite = Resources.Load<Sprite>("PlaceholderBombHeart");
        return sprite;
    }
}

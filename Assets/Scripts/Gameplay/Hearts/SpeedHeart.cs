using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Gameplay;
using UnityEngine;

public class SpeedHeart : Heart
{
    int speedHeartBonus = 3; // How much faster should 1 heart make us

    // Start is called before the first frame update
    void Start()
    {
        spr = setSprite();
        effects();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void onLoseHeart()
    {
        PlayerCharacterController playerController = FindObjectOfType<PlayerCharacterController>();
        playerController.MaxSpeedOnGround -= speedHeartBonus;
    }

    public override void effects()
    {
        //Do nothing
        PlayerCharacterController playerController = FindObjectOfType<PlayerCharacterController>();
        playerController.MaxSpeedOnGround += speedHeartBonus;
    }

    public override bool conditions()
    {
        return false;
    }

    public override Sprite setSprite()
    {
        var sprite = Resources.Load<Sprite>("PlaceholderSpeedHeart");
        return sprite;
    }
}

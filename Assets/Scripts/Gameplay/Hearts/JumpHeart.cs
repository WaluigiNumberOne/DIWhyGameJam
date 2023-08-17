using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Gameplay;
using UnityEngine;

public class JumpHeart : Heart
{
    int jumpHeartBonus = 2; // How much more force does 1 heart give us

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
        playerController.JumpForce -= jumpHeartBonus;
    }

    public override void effects()
    {
        //Do nothing
        PlayerCharacterController playerController = FindObjectOfType<PlayerCharacterController>();
        playerController.JumpForce += jumpHeartBonus;
    }

    public override bool conditions()
    {
        return false;
    }

    public override Sprite setSprite()
    {
        var sprite = Resources.Load<Sprite>("PlaceholderJumpHeart");
        return sprite;
    }
}

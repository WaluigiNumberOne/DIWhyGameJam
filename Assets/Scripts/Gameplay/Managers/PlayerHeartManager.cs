using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.FPS.Gameplay;
using UnityEngine;

public class PlayerHeartManager : MonoBehaviour
{
    public List<Heart> hearts = new List<Heart>();
    public Heart activeHeart;

    public bool Invincible;
    public bool tookDamage; //flag for Updating UI


    // Start is called before the first frame update
    void Start()
    {
        //Testing
        DefaultHeart dh = gameObject.AddComponent<DefaultHeart>();
        MetalHeart mh = gameObject.AddComponent<MetalHeart>();
        BombHeart bh = gameObject.AddComponent<BombHeart>();
        SpeedHeart sh = gameObject.AddComponent<SpeedHeart>();
        JumpHeart jh = gameObject.AddComponent<JumpHeart>();

        hearts.Add(dh);
        hearts.Add(sh);
        hearts.Add(bh);
        hearts.Add(mh);
        hearts.Add(jh);
        //---------------------------------------------------------

        setActiveHeart();

        tookDamage = true;

    }

    // Update is called once per frame
    void Update()
    {
        /*                                  TESTING DAMAGE
        if (Input.GetKeyDown(KeyCode.O))
        {
            takeDamage(1f);
        }
        */
    }

    public void setActiveHeart()
    {
        try
        {
            activeHeart = hearts.Last();
            activeHeart.active = true;
        }
        catch (System.Exception)
        {
            //No hearts in list so youre dead probably
            Die();
        }
    }

    public void takeDamage(float dmg)
    {
        if(!Invincible)
        {
            //do damage to active heart

            activeHeart.hp -= dmg;
            if(activeHeart.hp <= 0)
            {
                LoseHeart();
            }
            tookDamage = true;
        }
    }

    private void Die()
    {
        //oof ouch ow
        Debug.Log("You idiot you ran out of hearts now youre dead I hate you");
        //PlayerCharacterController pcc = FindObjectOfType<PlayerCharacterController>();
        //pcc.OnDie();
    }

    private void LoseHeart()
    {
        activeHeart.onLoseHeart();

        hearts.Remove(activeHeart);
        Debug.Log("lost heart");

        setActiveHeart();
    }
}

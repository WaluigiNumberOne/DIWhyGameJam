using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        hearts.Add(dh);
        hearts.Add(dh);
        hearts.Add(dh);
        hearts.Add(mh);
        //---------------------------------------------------------

        setActiveHeart();

        tookDamage = true;

    }

    // Update is called once per frame
    void Update()
    {
        /*                                      TESTING DAMAGE
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
    }

    private void LoseHeart()
    {
        hearts.Remove(activeHeart);
        Debug.Log("lost heart");


        setActiveHeart();
    }
}

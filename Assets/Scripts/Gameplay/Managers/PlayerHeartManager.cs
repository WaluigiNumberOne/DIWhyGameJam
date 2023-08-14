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
    }

    public void setActiveHeart()
    {
        activeHeart = hearts.Last();
        if(!activeHeart)
        {
            Die();
        }
        else
        {
            activeHeart.active = true;
        }
    }

    public void takeDamage()
    {
        if(!Invincible)
        {
            //do damage
            tookDamage = true;
        }
    }

    private void Die()
    {

    }
}

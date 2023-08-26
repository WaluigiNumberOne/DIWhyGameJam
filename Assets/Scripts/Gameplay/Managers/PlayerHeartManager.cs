using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.FPS.Gameplay;
using UnityEngine;

public class PlayerHeartManager : MonoBehaviour
{
    public List<Heart> hearts = new List<Heart>();
    public Heart activeHeart;
    public int activeHeartType;

    public bool Invincible;
    public bool healthChanged; //flag for Updating UI


    // Start is called before the first frame update
    void Start()
    {
        //Testing
        AddHeart(0);
        AddHeart(1);
        AddHeart(2);
        AddHeart(3);
        AddHeart(4);
        AddHeart(6);

        //---------------------------------------------------------

        setActiveHeart();

        healthChanged = true;

    }

    // Update is called once per frame
    void Update()
    {
        ///*                                  TESTING DAMAGE
        if (Input.GetKeyDown(KeyCode.O))
        {
            takeDamage(1f);
        }
        //*/
    }

    public void setActiveHeart()
    {
        try
        {
            activeHeart = hearts.Last();
            activeHeart.active = true;
            activeHeartType = activeHeart.type;
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
            healthChanged = true;
        }
    }

    public void AddHeart(int type)
    {    
        //0 ->  default heart
        //1 ->  speed heart
        //2 ->  jump heart
        //3 ->  metal heart
        //4 ->  bomb heart
        //5 ->  copy heart                  DOES NOT HAVE ACTIVE TYPE BECAUSE IT JUST COPIES A DIFFERENT ONE
        //6 ->  rechargeable heart

        switch(type)
        {
            case 0:
                hearts.Add(gameObject.AddComponent<DefaultHeart>());
                break;
            case 1:
                hearts.Add(gameObject.AddComponent<SpeedHeart>());
                break;
            case 2:
                hearts.Add(gameObject.AddComponent<JumpHeart>());
                break;
            case 3:
                hearts.Add(gameObject.AddComponent<MetalHeart>());
                break;
            case 4:
                hearts.Add(gameObject.AddComponent<BombHeart>());
                break;
            case 5:
                hearts.Add(gameObject.AddComponent<CopyHeart>());
                break;
            case 6:
                hearts.Add(gameObject.AddComponent<RechargeableHeart>());
                break;
            default:
                break;
        }
        healthChanged = true;

        if(activeHeart) activeHeart.active = false;

        setActiveHeart();
    }

    private void Die()
    {
        //oof ouch ow
        Debug.Log("You idiot you ran out of hearts now youre dead I hate you");
        PlayerCharacterController pcc = FindObjectOfType<PlayerCharacterController>();
        pcc.OnDie();
    }

    private void LoseHeart()
    {
        activeHeart.onLoseHeart();

        hearts.Remove(activeHeart);
        Debug.Log("lost heart");
        Destroy(activeHeart);

        setActiveHeart();
    }

}

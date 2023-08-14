using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerHeartManager : MonoBehaviour
{
    private List<Heart> hearts = new List<Heart>();
    private Heart activeHeart;


    // Start is called before the first frame update
    void Start()
    {
        DefaultHeart dh = gameObject.AddComponent<DefaultHeart>();
        MetalHeart mh = gameObject.AddComponent<MetalHeart>();

        hearts.Add(dh);
        hearts.Add(mh);

        setActiveHeart();

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void setActiveHeart()
    {
        activeHeart = hearts.Last();
        activeHeart.active = true;
    }
}

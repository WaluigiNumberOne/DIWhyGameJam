using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    float MIN_RADIUS = .5f;
    float MAX_RADIUS = 2f;
    float explosionTime = .5f;      //seconds
    float explosionSpeed;

    SphereCollider collider;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Explosion Created");
        collider = GetComponent<SphereCollider>();
        collider.radius = MIN_RADIUS;

         explosionSpeed = (MAX_RADIUS - MIN_RADIUS) / explosionTime;    //units per second
    }

    // Update is called once per frame
    void Update()
    {
        if(collider.radius <= MAX_RADIUS)
        {
            float explosionSpeed = (MAX_RADIUS - MIN_RADIUS) / explosionTime;
            //Expand
            collider.radius += explosionSpeed * Time.deltaTime;
        }
        else
        {
            //die lol
            Destroy(gameObject);
        }
    }
}

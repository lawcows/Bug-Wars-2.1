using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBG : MonoBehaviour
{

    private float length, starpos, parallaxEffectAcc;
    public float parallaxEffect;
    
    void Start()
    {
        starpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;   
    }

    
    void Update()
    {

        parallaxEffectAcc -= parallaxEffect / 1000.0f;
        float temp = (1 - parallaxEffectAcc);
        float dist = (parallaxEffectAcc);

        transform.position = new Vector3(starpos + dist, transform.position.y, transform.position.z);

        if (temp > starpos + length) starpos += length;
        else if (temp < starpos - length) starpos -= length;
    }
}

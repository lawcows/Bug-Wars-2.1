using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Material material;
    void Start()
    {
        if(SelectPlayer.greenPlayerSelected)
        {
            material.color = new Color(1,161,108,255);
        }
        if(SelectPlayer.redPlayerSelected)
        {
            material.color = new Color(255,0,170,255);
        }
        if(SelectPlayer.fusionPlayerSelected)
        {
            material.color = new Color(255,245,0,255);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

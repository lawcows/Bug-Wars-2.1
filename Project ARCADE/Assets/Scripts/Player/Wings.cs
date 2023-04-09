using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wings : MonoBehaviour
{
    public float wingSpeed;
    public float wingRotation;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {        
        wingRotation = Mathf.PingPong(Time.time * wingSpeed*1000, 90);
        transform.rotation = Quaternion.AngleAxis(wingRotation,Vector3.right);
    }

    // se o valor da rotação for menor que 45, wingRotation é Vector3.right
}

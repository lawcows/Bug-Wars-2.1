using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] Transform cameraGO;
    public float cameraSpeed;
    void Start()
    {
        
    }

    void Update()
    {
        cameraGO.position = new Vector3 (cameraGO.position.x, cameraGO.transform.position.y, cameraGO.transform.position.z + cameraSpeed*0.01f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    void Start()
    {
        
    }

    
    void LateUpdate()
    {
        //verilen offset ile karakteri takip ettirdim.
        transform.position = target.position + offset;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Target;
    
    void Update()
    {
        if (!Target) return;
        Vector3 position = transform.position;
        position.x = Target.transform.position.x;
        position.y = Target.transform.position.y;
        transform.position = position;
    }
}

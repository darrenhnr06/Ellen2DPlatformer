using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothfactor;

    
    void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        Vector3 targetposition = target.position + offset;
        Vector3 smoothposition = Vector3.Lerp(transform.position, targetposition, smoothfactor * Time.fixedDeltaTime);
        transform.position = smoothposition;
    }
}

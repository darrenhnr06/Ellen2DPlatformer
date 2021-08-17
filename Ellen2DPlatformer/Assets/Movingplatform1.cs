using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movingplatform1 : MonoBehaviour
{
    public GameObject gameObject1;
    public GameObject gameObject2;
    private Vector3 position;
   
    void Update()
    {
        Vector3 vector3 = Vector3.Lerp(gameObject1.transform.position, gameObject2.transform.position, 5);
        position = vector3;
        transform.position = position;
    }
}

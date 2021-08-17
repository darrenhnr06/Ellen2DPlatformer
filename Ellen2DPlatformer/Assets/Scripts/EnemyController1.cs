using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController1 : MonoBehaviour
{
    Vector3 vectorpos;
    Vector3 vectorscale;
    private double a;
    private int k;
    private float timer = 30f;


    private void Awake()
    {
        vectorpos = gameObject.transform.position;
        vectorscale = gameObject.transform.localScale;
        a = vectorpos.x;
        k = 0;
    }
    private void Update()
    {
        timer -= 0.1f;

        if (k == 0)
        {
            vectorpos.x += -0.025f;
            if (timer <= 0.0f)
            {
                k = 1;
                vectorscale.x *= -1;
                timer = 30f;
            }
        }
        else if (k == 1)
        {
            vectorpos.x += 0.025f;
            if (timer <= 0.0f)
            {
                k = 0;
                vectorscale.x *= -1;
                timer = 30f;
            }

        }
        gameObject.transform.position = vectorpos;
        gameObject.transform.localScale = vectorscale;
    }
}

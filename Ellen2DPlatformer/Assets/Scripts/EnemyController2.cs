using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController2 : MonoBehaviour
{
    public Animator animator;
    Vector3 vectorpos;
    public EnemyEnter enemyEnter;
    

    private void Awake()
    {
        vectorpos = gameObject.transform.position;
    }
    private void Update()
    {
        vectorpos.x += -0.05f;
        gameObject.transform.position = vectorpos;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyExit>() != null)
        {
            vectorpos = enemyEnter.gameObject.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        vectorpos = enemyEnter.gameObject.transform.position;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalLevelController1 : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController1>() != null)
        {

            SceneManager.LoadScene(2);
        }
    }
    void Start()
    {
        Debug.Log("Level Started");
    }
}

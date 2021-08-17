using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController1 : MonoBehaviour
{
    public Canvas canvas;
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController1>() != null)
        {
            Gotonextlevel();
        }
    }

    IEnumerator Enablecanvas()
    {
        canvas.gameObject.SetActive(true);
        yield return new WaitForSeconds(10f);
    }

    void Gotonextlevel()
    {
        StartCoroutine(Enablecanvas());
        Levelmanager.Instance.Setlevelstatus("Level2", Levelstatus.unlocked);
        SceneManager.LoadScene(1);
    }

    void Start()
    {
        Debug.Log("Level Started");
    }
}

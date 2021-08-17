using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttoncontroller2 : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;

    private void Awake()
    {
        button1.onClick.AddListener(Startgame);
        button2.onClick.AddListener(Currentgame);
        button3.onClick.AddListener(Startlobby);
        button4.onClick.AddListener(Endgame);
    }
    void Startlobby()
    {
        SceneManager.LoadScene("Lobby Scene");
    }

    void Endgame()
    {
        Application.Quit();
    }

    void Currentgame()
    {
        SceneManager.LoadScene(Currentscene.currentscene);
    }

    void Startgame()
    {
        SceneManager.LoadScene("Level1");
    }
}

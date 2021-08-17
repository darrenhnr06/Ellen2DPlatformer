using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttoncontroller : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;

    private void Awake()
    {
        button1.onClick.AddListener(Startgame);
        button2.onClick.AddListener(Endgame);
        button3.onClick.AddListener(Currentgame);
        button4.onClick.AddListener(Loadleveltwo);
    }
   void Startgame()
    {
        SceneManager.LoadScene("Level1");
    }

    void Endgame()
    {
        Application.Quit();
    }

    void Currentgame()
    {
        SceneManager.LoadScene(Currentscene.currentscene);
    }

    void Loadlevel(string level)
    {
        if (Levelmanager.Instance.Getlevelstatus(level) == Levelstatus.unlocked)
        {
            SceneManager.LoadScene(level);
        }
    }

    void Loadleveltwo()
    {
        Loadlevel("Level2");
    }
}

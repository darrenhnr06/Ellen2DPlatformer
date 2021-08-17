using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController1 : MonoBehaviour
{
    public Button button;
    private void Awake()
    {
        Debug.Log("Button Clicked");
        button.onClick.AddListener(StartLevel);
    }


    private void StartLevel()
    {
        SceneManager.LoadScene("Lobby Scene");
    }
}

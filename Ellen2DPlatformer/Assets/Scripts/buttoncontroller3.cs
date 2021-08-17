using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttoncontroller3 : MonoBehaviour
{
    public Button button;

    private void Awake()
    {
        button.onClick.AddListener(Buttonfunction);
    }

    void Buttonfunction()
    {
        SceneManager.LoadScene("Lobby Scene");
    }
}

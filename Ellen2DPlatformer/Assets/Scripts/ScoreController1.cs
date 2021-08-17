using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreController1 : MonoBehaviour
{
    Scene scene;
    private int score;
    private TextMeshProUGUI textmeshpro;
    public void Updatescore()
    {
        score += 10;
        textmeshpro.text = "Score: " + score;
        
        if (scene.name == "Level1")
        {
            PlayerPrefs.SetInt("score", score);
        }
    }
    private void Awake()
    {
        scene = SceneManager.GetActiveScene();
        textmeshpro = gameObject.GetComponent<TextMeshProUGUI>();
        if (scene.name == "Level1") 
        {
            score = 0;
        }
        else if(scene.name == "Level2")
        {
            score = PlayerPrefs.GetInt("score");
            textmeshpro.text = "Score: " + score;
        }
        
    }
}

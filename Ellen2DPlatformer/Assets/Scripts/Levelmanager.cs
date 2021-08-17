using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levelmanager : MonoBehaviour
{
    private static Levelmanager instance;
    public static Levelmanager Instance {get { return instance; } }

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        Setlevelstatus("Level1", Levelstatus.unlocked);
    }

    public void Setlevelstatus(string level,Levelstatus levelstatus)
    {
        PlayerPrefs.SetInt(level, (int)levelstatus);
    }

    public Levelstatus Getlevelstatus(string level)
    {
        return (Levelstatus)PlayerPrefs.GetInt(level);
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }

    public SoundType[] sounds;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    } 

    public void Play(Sounds sound)
    {
        SoundType item = Array.Find(sounds, item => item.soundtype == sound);
        item.soundClip.Play();
    }

    [Serializable]
    public class SoundType
    {
        public Sounds soundtype;
        public AudioSource soundClip;
    }

    public enum Sounds
    {

       ButtonClick,
       PlayerDeath,
       PlayerRun,
       PlayerJump,
       JetPack,
    }



}

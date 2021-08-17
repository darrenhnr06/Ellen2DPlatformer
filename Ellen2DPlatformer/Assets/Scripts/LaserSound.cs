using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSound : MonoBehaviour
{
    public AudioSource audioSource;
    int k = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.X)&&k==0)
        {
            audioSource.Play();
            k = 1;
        }
        else if (!(Input.GetKey(KeyCode.X)))
        {
            k = 0;
            audioSource.Stop();
        }
    }
}

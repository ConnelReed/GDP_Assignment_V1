using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{

    //DECLARE PUBLIC VARIABLES
    public AudioClip Sound_File;
    public Object obj = null;
    public int Wait = 0;
    public int Wait_Max = 20;
    public bool Played_Audio = false;
    public 

    // Use this for initialization
    void Start()
    {
        //FIND THE AUDIO SOURCe
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = Sound_File;

    }

    private void Update()
    {
        Wait += 1;

        if (Wait >= Wait_Max)
        {
            Wait = Wait_Max;
        }
    }

    void OnCollisionEnter()
    {
        if (Played_Audio == false)
        {
            if (Wait == Wait_Max)
            {

                Debug.Log("* Audio Playing on Collision Enter *");
                GetComponent<AudioSource>().PlayOneShot(Sound_File);
                
            }
        }
        if (obj.name == "buttonend")
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene(0);
            //string currentSceneName = SceneManager.GetActiveScene().name;
            // SceneManager.LoadScene(currentSceneName);
            Time.timeScale = 1;
            Wait = 0;
        }
        
       
    }
    
}

//SceneManager.LoadScene(SceneManager.GetActiveScene().name);

//https://answers.unity.com/questions/1159138/playing-audio-on-collision.html
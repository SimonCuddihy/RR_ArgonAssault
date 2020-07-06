using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;


public class MusicPlayer : MonoBehaviour
{
    private float splashScreenDelay = 360f;

    // Awake is called before Start
    private void Awake()
    {
        MusicPlayer musicPlayerGameObject = FindObjectOfType<MusicPlayer>();
        DontDestroyOnLoad(musicPlayerGameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadFirstScene();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadSplashScreen(); // TODO: audio plays again over original audio when going back to splash screen
        }
        else
        {
            Invoke("LoadFirstScene", splashScreenDelay);
        }
    }

    void LoadSplashScreen()
    {
        SceneManager.LoadScene(0);
    }

    void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }
}

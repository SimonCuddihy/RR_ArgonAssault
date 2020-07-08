using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private float splashScreenDelay = 360f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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

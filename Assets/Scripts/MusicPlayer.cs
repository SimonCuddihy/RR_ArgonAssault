using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class MusicPlayer : MonoBehaviour
{
    private float splashScreenDelay = 360f;

    // Start is called before the first frame update
    void Start()
    {
        if (Input.anyKeyDown)
        {
            LoadFirstScene();
        }
        else
        {
            Invoke("LoadFirstScene", splashScreenDelay); 
        }
    }

    void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }
}

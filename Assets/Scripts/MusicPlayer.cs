using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;



public class MusicPlayer : MonoBehaviour
{
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
}

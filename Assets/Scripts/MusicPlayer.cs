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
        int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length; 
        
        if (numMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);   
        }
    }
}

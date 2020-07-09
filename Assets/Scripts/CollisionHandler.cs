using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("In seconds")] [SerializeField] private float levelLoadDelay = 1f;
    [Tooltip("explosion FX in player")] [SerializeField] private GameObject deathFX = null;

    void OnTriggerEnter(Collider other)
    {
        OnDeathSequence();
    }

    private void OnDeathSequence()
    {
        SendMessage("OnPlayerDeath");
        deathFX.SetActive(true);
        Invoke("ReloadLevel",levelLoadDelay);
    }

    void ReloadLevel() // string referenced
    {
        SceneManager.LoadScene(1);
    }
}

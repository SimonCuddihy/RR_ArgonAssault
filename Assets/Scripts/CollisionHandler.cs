using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        OnDeathSequence();
    }

    private void OnDeathSequence()
    {
        print("Player dying");
        SendMessage("OnPlayerDeath");
    }
}

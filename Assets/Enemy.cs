using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Tooltip("In seconds")] [SerializeField] private float levelLoadDelay = 1f;
    [Tooltip("explosion FX in player")] [SerializeField] private GameObject deathFX = null;

    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerBoxCollider();
    }

    private void AddNonTriggerBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnParticleCollision(GameObject other)
    {
        print("Particles collided with" + gameObject.name);
        deathFX.SetActive(true);
        Invoke("OnEnemyDestroyed",levelLoadDelay);
    }

    private void OnEnemyDestroyed()
    {
        Destroy(gameObject);
    }
}

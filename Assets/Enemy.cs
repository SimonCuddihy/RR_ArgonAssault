using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Tooltip("In seconds")] [SerializeField] private float levelLoadDelay = 0.5f;
    [Tooltip("explosion FX in player")] [SerializeField] private GameObject deathFX;
    [Tooltip("where objects go to die")] [SerializeField] private Transform parent;


    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerBoxCollider();
    }

    private void AddNonTriggerBoxCollider()
    {
        BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnParticleCollision(GameObject other)
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Invoke("OnEnemyDestroyed",levelLoadDelay);
        print("Particles collided with" + gameObject.name);
    }

    private void OnEnemyDestroyed()
    {
        Destroy(gameObject);
    }
}

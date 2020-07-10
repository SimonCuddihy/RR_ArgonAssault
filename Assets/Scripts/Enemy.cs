using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Tooltip("explosion FX in player")] [SerializeField] private GameObject deathFX;
    [Tooltip("where objects go to die")] [SerializeField] private Transform parent;
    ScoreBoard scoreBoard;
    [SerializeField] private int hitPool = 50;

    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
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
        scoreBoard.ScoreHit();
        hitPool--;
        // todo consider hit effects
        if (hitPool <  1)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}

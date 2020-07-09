using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructor : MonoBehaviour
{
    [SerializeField] private float timeToSelfDestruct = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeToSelfDestruct); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

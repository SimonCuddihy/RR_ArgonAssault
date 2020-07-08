using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class TranslatePos : MonoBehaviour
{
    private Vector3 startingPos;
    private Vector3 rotationPos;
    [SerializeField] private Vector3 movementVector = new Vector3(0.30f, 0.20f, 0.15f);
    [Range(0, 1)] [SerializeField] private float movementFactor; // 0 for not moved, 1 for fully moved
    [SerializeField] private float period = 3f;

    //[Range(-5,5)] Vector3 moveLeft = Vector3.left;
    //[Range(-5,5)] Vector3 moveRight = Vector3.right;
    //[Range(-5,5)] Vector3 moveUp = Vector3.up;
    //[Range(-5,5)] Vector3 moveDown = Vector3.down;

    
    // Start is called before the first frame update
    private void Start()
    {
        startingPos = transform.position;
    }
    

    // Update is called once per frame
    private void Update()
    {
        autoMove();
    }

    // set movement factor automatically
    private void autoMove()
    {
        if (period <= Mathf.Epsilon) return;

        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2f; // about 6.28 radians

        float rawSinWave = Mathf.Sin(cycles * tau); // sin wave amplitude goes between +1 and -1
        movementFactor = rawSinWave / 2f + 0.5f; // sin wave between +1 and -0

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
    }
}

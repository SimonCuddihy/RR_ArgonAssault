using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In m/s")][SerializeField] private float moveSpeed = 20f;
    private float horizontalInput;
    private float verticalInput;

    [SerializeField] float verticalPositionLimit = 14f;
    [SerializeField] float horizontalPositionLimit = 20f;

    // pitch control
    [SerializeField] float yPositionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -15f;
    
    // yaw control
    [SerializeField] float xPositionYawFactor = 2.2f;

    // roll control
    [SerializeField] float controlRollFactor = -3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        float pitchDueToYPosition = transform.localPosition.y * yPositionPitchFactor;
        float pitchDueToControlFactor = verticalInput * controlPitchFactor;
        float pitch = pitchDueToYPosition + pitchDueToControlFactor;

        float yaw = transform.localPosition.x * xPositionYawFactor;

        float rollDueToControlFactor = horizontalInput * controlRollFactor;
        float roll = transform.localPosition.z * rollDueToControlFactor;
        
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        // Ben's Solution
        horizontalInput = CrossPlatformInputManager.GetAxis("Horizontal");
        verticalInput = CrossPlatformInputManager.GetAxis("Vertical");
        float offset = moveSpeed * Time.deltaTime;
        float xOffset = horizontalInput * offset;
        float yOffset = verticalInput * offset;
        float rawXPos = transform.localPosition.x + xOffset;
        float rawYPos = transform.localPosition.y + yOffset;
        float restrictedXPos = Mathf.Clamp(rawXPos, -horizontalPositionLimit, horizontalPositionLimit);
        float restrictedYPos = Mathf.Clamp(rawYPos, -verticalPositionLimit, verticalPositionLimit);

        transform.localPosition = new Vector3(restrictedXPos, restrictedYPos, transform.localPosition.z);

        // UNITY's Solution:
        // todo: following solution is much simpler - possibly use this in future
        //float horizontalInput = CrossPlatformInputManager.GetAxis("Horizontal");
        //float verticalInput = CrossPlatformInputManager.GetAxis("Vertical");
        //transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * offset);
    }
}

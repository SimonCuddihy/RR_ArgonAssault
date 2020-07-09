using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header("Player Speed")]
    [Tooltip("In m/s")][SerializeField] private float moveSpeed = 50f;

    // player movement limits on screen
    [Header("Player Movement Bounds")]
    [SerializeField] float verticalPositionLimit = 14f;
    [SerializeField] float horizontalPositionLimit = 25f;

    [Header("Position-Based Sensitivity")]
    [SerializeField] float yPositionPitchFactor = -2f; // pitch control
    [SerializeField] float xPositionYawFactor = 2.2f; // yaw control

    [Header("Control-Based Sensitivity")]
    [SerializeField] float controlPitchFactor = -15f; // pitch control
    [SerializeField] float controlRollFactor = -4f; // roll control
    

    // member variables
    private float horizontalInput;
    private float verticalInput;
    private bool isControlEnabled = true;

    // Update is called once per frame
    void Update()
    {
        if (isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
        }
    }

    private void OnPlayerDeath() // called by string reference
    {
        isControlEnabled = false;
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

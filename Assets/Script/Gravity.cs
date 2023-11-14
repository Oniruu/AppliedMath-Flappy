using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGravity : MonoBehaviour
{
    public float gravity = 9.8f;  // Adjust this value to control the strength of gravity
    private float verticalVelocity = 0f;

    void Update()
    {
        // Apply gravity using a kinematic equation: v = u + at
        verticalVelocity -= gravity * Time.deltaTime;

        // Update the character's position based on the calculated velocity
        transform.Translate(Vector3.up * verticalVelocity * Time.deltaTime);
    }

    // Call this method to make the character jump (apply an upward force)
    public void Jump(float jumpForce)
    {
        // Set the vertical velocity to the jump force
        verticalVelocity = jumpForce;
    }
}
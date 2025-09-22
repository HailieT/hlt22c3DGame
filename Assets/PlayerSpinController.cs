using UnityEngine;

/// <summary>
/// This script goes on the player. It receives commands from platforms
/// to start or stop spinning and handles its own rotation.
/// It also hides/locks the mouse cursor during the spin.
/// </summary>
public class PlayerSpinController : MonoBehaviour
{
    private bool shouldSpin = false;
    private Vector3 spinSpeed;

    void Update()
    {
        // If the variable is true, apply the rotation every frame.
        if (shouldSpin)
        {
            transform.Rotate(spinSpeed * Time.deltaTime);
        }
    }

    /// <summary>
    /// This public method is called by the platform to start the spin.
    /// </summary>
    public void StartSpinning(Vector3 newSpinSpeed)
    {
        shouldSpin = true;
        spinSpeed = newSpinSpeed;

        // --- NEW CODE: Turn the mouse 'off' ---
        Cursor.lockState = CursorLockMode.Locked; // Locks the cursor to the center of the screen.
        Cursor.visible = false;                   // Hides the cursor.
    }

    /// <summary>
    /// This public method is called by the platform to stop the spin.
    /// </summary>
    public void StopSpinning()
    {
        shouldSpin = false;

        // --- NEW CODE: Turn the mouse back 'on' ---
        Cursor.lockState = CursorLockMode.None;   // Unlocks the cursor.
        Cursor.visible = true;                    // Makes the cursor visible again.
    }
}
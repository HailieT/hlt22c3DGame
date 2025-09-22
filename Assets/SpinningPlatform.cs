using UnityEngine;

/// <summary>
/// This script goes on the platform. It detects the player and tells the player's
/// script to start or stop spinning, passing along its rotation speed.
/// </summary>
public class SpinningPlatform : MonoBehaviour
{
    [Tooltip("The rotation speed to pass to the character (X, Y, Z).")]
    public Vector3 rotationSpeed = new Vector3(0, 100, 0);

    private void OnCollisionEnter(Collision collision)
    {
        // Try to get the PlayerSpinController component from the object we hit.
        PlayerSpinController player = collision.gameObject.GetComponent<PlayerSpinController>();

        // If the object has the script, tell it to start spinning.
        if (player != null)
        {
            player.StartSpinning(rotationSpeed);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Try to get the PlayerSpinController component from the object that left.
        PlayerSpinController player = collision.gameObject.GetComponent<PlayerSpinController>();

        // If the object has the script, tell it to stop spinning.
        if (player != null)
        {
            player.StopSpinning();
        }
    }
}

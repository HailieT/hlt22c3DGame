using UnityEngine;

public class PhysicsSpinner : MonoBehaviour
{
    [SerializeField] private float spinForce = 50f;

    private Rigidbody platformRigidbody;

    private void Start()
    {
        platformRigidbody = GetComponent<Rigidbody>();
        if (platformRigidbody == null)
        {
            Debug.LogError("This script requires a Rigidbody component on the platform.");
        }
    }

    private void FixedUpdate()
    {
        // Apply the continuous rotation in FixedUpdate for physics consistency
        // This assumes you are spinning it via script.
        // If using an Animator, this part is not needed.
        Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, spinForce * Time.fixedDeltaTime, 0));
        platformRigidbody.MoveRotation(platformRigidbody.rotation * deltaRotation);
    }

    private void OnCollisionStay(Collision collision)
    {
        Rigidbody playerRigidbody = collision.collider.GetComponent<Rigidbody>();

        if (playerRigidbody != null)
        {
            // Calculate the velocity of the platform at the contact point
            Vector3 contactPoint = collision.contacts[0].point;
            Vector3 platformVelocity = platformRigidbody.GetPointVelocity(contactPoint);

            // Apply this velocity to the player
            playerRigidbody.AddForce(platformVelocity, ForceMode.Acceleration);
        }
    }
}
using UnityEngine;

/// <summary>
/// Continuously rotates the GameObject and makes any object with the specified tag
/// a child when it stands on top, so it rotates along with this object.
/// </summary>
public class ObjectSpinner : MonoBehaviour
{
    [Header("Rotation Settings")]
    [Tooltip("The speed of rotation around each axis (X, Y, Z).")]
    [SerializeField] private Vector3 rotationSpeed = new Vector3(0, 50, 0);

    [Header("Parenting Settings")]
    [Tooltip("The tag of the object to parent (e.g., 'Player').")]
    [SerializeField] private string targetTag = "Player";

    // Update is called once per frame
    void Update()
    {
        // Rotate the platform
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }

    // This function is called when another collider enters this object's collider.
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object that touched us has the correct tag.
        if (collision.gameObject.CompareTag(targetTag))
        {
            // If it's the player, make the player a child of this platform.
            // Now, when the platform spins, the player will spin with it.
            collision.gameObject.transform.SetParent(transform);
        }
    }

    // This function is called when another collider stops touching this object's collider.
    private void OnCollisionExit(Collision collision)
    {
        // Check if the object that left us has the correct tag.
        if (collision.gameObject.CompareTag(targetTag))
        {
            // If it's the player, un-parent them by setting their parent to null.
            // This detaches the player from the platform, so they no longer spin with it.
            collision.gameObject.transform.SetParent(null);
        }
    }
}
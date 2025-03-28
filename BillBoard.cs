using UnityEngine;

public class Billboard : MonoBehaviour
{
    void LateUpdate() // Use LateUpdate instead of Update
    {
        if (Camera.main != null)
        {
            Vector3 targetPosition = Camera.main.transform.position;
            targetPosition.y = transform.position.y; // Keep it level (optional)
            transform.LookAt(targetPosition);
            transform.Rotate(0, 180, 0); // Flip it correctly
        }
    }
}

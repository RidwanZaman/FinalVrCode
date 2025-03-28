using UnityEngine;

public class BillboardUI : MonoBehaviour
{
    public Transform cameraTransform; // Assign the VR Camera (Main Camera)
    public float d = 2f;
    public float x = -0.8f;
    public float y = -5;

    void Start()
    {
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform; // Auto-assign if not set
        }
    }

    void LateUpdate()
    {
        // Set base position in front of the camera
        transform.position = cameraTransform.position + cameraTransform.forward * d;

        // Align rotation with the camera
        transform.rotation = cameraTransform.rotation;

        // Offset to the right (adjust values as needed)
        transform.position += cameraTransform.right * x; // Move right (use -0.8f to move left)
        transform.position += cameraTransform.up * y; // Move down (use positive to move up)
    }

}

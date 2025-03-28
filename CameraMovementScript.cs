using UnityEngine;

public class CameraMovementSound : MonoBehaviour
{
    public AudioSource movementAudioSource;
    private Vector3 lastPosition;

    void Start()
    {
        if (movementAudioSource == null)
        {
            Debug.LogError("Movement Audio Source is not set.");
        }
        lastPosition = transform.position;
    }

    void Update()
    {
        // Check if the camera is moving
        if (transform.position != lastPosition)
        {
            if (!movementAudioSource.isPlaying)
            {
                movementAudioSource.Play();
            }
        }
        else
        {
            if (movementAudioSource.isPlaying)
            {
                movementAudioSource.Stop();
            }
        }

        // Update the last position
        lastPosition = transform.position;
    }
}
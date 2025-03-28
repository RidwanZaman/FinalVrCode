using UnityEngine;

public class PufferfishMovement : MonoBehaviour
{
    public float speed = 2f;          // Speed of movement
    public float moveDistance = 0.2f;   // Distance to move back and forth
    public bool smoothMovement = true; // Use smooth (sin-wave) movement

    private Vector3 startPosition;
    private bool movingForward = true;

    void Start()
    {
        startPosition = transform.position;  // Save initial position
    }

    void Update()
    {
        MovePufferfish();
    }

    void MovePufferfish()
    {
        if (smoothMovement)
        {
            // Smooth floating movement (sin-wave effect)
            float offset = Mathf.Sin(Time.time * speed) * moveDistance;
            transform.position = startPosition + new Vector3(0, offset, 0);
        }
        else
        {
            // Linear back and forth movement
            float moveStep = speed * Time.deltaTime;
            if (movingForward)
            {
                transform.position += new Vector3(moveStep, 0, 0);
                if (Vector3.Distance(startPosition, transform.position) >= moveDistance)
                    movingForward = false;
            }
            else
            {
                transform.position -= new Vector3(moveStep, 0, 0);
                if (Vector3.Distance(startPosition, transform.position) <= 0.1f)
                    movingForward = true;
            }
        }
    }
}

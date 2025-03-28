using UnityEngine;

public class FishCircularMovement : MonoBehaviour
{
    public float radius = 2f;   // Radius of the circular motion
    public float speed = 0.5f;    // Speed of the movement

    private float angle = 0f;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position; // Save initial position
    }

    void Update()
    {
        MoveInCircle();
    }

    void MoveInCircle()
    {
        // Increment angle over time to create circular motion
        angle += speed * Time.deltaTime;

        // Calculate new position using sine & cosine functions
        float x = Mathf.Cos(angle) * radius;
        float z = Mathf.Sin(angle) * radius;

        // Update position
        transform.position = startPosition + new Vector3(x, 0, z);

        // Rotate fish to face the movement direction
        Vector3 direction = new Vector3(-Mathf.Sin(angle), 0, Mathf.Cos(angle)); // Tangent to the circle
        transform.rotation = Quaternion.LookRotation(direction);
    }
}

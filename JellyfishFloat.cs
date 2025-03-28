using UnityEngine;

public class JellyfishFloat : MonoBehaviour
{
    private float baseFloatSpeed = 0.7f;
    private float floatSpeedVariation = 0.5f; // Adjust range as needed
    private float floatHeight = 0.1f;

    private Vector3 startPos;
    private float floatSpeed;

    void Start()
    {
        startPos = transform.position;
        floatSpeed = baseFloatSpeed + Random.Range(-floatSpeedVariation, floatSpeedVariation);
    }

    void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}

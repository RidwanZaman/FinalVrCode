using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour
{
    public float speed = 0.5f;  // Movement speed
    public float turnSpeed = 1f;  // Rotation speed
    public float changeDirectionTime = 3f;  // Time before choosing a new direction
    public float swimRadius = 5f;  // Maximum swim area

    private Vector3 targetPosition;

    void Start()
    {
        ChooseNewTargetPosition();
        StartCoroutine(ChangeDirectionRoutine());
    }

    void Update()
    {
        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Smoothly rotate towards movement direction
        Vector3 direction = (targetPosition - transform.position).normalized;
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        }

        // If close to the target, pick a new one
        if (Vector3.Distance(transform.position, targetPosition) < 0.5f)
        {
            ChooseNewTargetPosition();
        }
    }

    void ChooseNewTargetPosition()
    {
        Vector3 randomOffset = new Vector3(
            Random.Range(-swimRadius, swimRadius),
            Random.Range(-1f, 1f),  // Slight vertical movement
            Random.Range(-swimRadius, swimRadius)
        );

        targetPosition = transform.position + randomOffset;
    }

    IEnumerator ChangeDirectionRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(changeDirectionTime);
            ChooseNewTargetPosition();
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class ArrowManager : MonoBehaviour
{
    public Transform playerCamera;      // Assign your XR camera here
    public Transform[] questTargets;    // Assign the targets (Crayfish, Turtle, Oyster, etc.)
    public GameObject arrowPanel;       // Your ^ arrow UI panel

    public float showAngle = 30f;       // Adjust sensitivity (smaller = stricter)

    private int currentQuestIndex = 0;

    void Update()
    {
        if (currentQuestIndex >= questTargets.Length) return; // No more quests

        // Direction player is looking
        Vector3 forward = playerCamera.forward;
        Vector3 toTarget = (questTargets[currentQuestIndex].position - playerCamera.position).normalized;

        float angle = Vector3.Angle(forward, toTarget);

        if (angle < showAngle)
        {
            arrowPanel.SetActive(true); // Show arrow
        }
        else
        {
            arrowPanel.SetActive(false); // Hide arrow
        }
    }

    public void UpdateArrowTarget(int questID)
    {
        currentQuestIndex = questID;
    }
}

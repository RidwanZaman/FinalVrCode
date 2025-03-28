using UnityEngine;

public class CoralInteraction2 : MonoBehaviour
{
    public GameObject interactUI;       // "!" Indicator
    public GameObject guidingQPanel;    // Guiding Panel
    public Transform focusPoint;        // Camera focus target

    private bool canInteract = false;
    private bool hasInteracted = false;
    private bool interactionInProgress = false;

    void Start()
    {
        interactUI.SetActive(true);
        guidingQPanel.SetActive(false);
        Debug.Log("Coral interaction initialized");
    }

    void Update()
    {
        if (canInteract && !hasInteracted && !interactionInProgress && AnyVRInputPressed())
        {
            StartInteraction();
        }
    }

    private bool AnyVRInputPressed()
    {
        // Check all common VR controller buttons
        return Input.GetKeyDown(KeyCode.JoystickButton0) ||  // Typically 'A' on Oculus, 'X' on Vive
               Input.GetKeyDown(KeyCode.JoystickButton1) ||  // Typically 'B' on Oculus, 'Y' on Vive
               Input.GetKeyDown(KeyCode.JoystickButton2) ||  // Typically 'X' on Oculus, unused on Vive
               Input.GetKeyDown(KeyCode.JoystickButton3) ||  // Typically 'Y' on Oculus, unused on Vive
               Input.GetKeyDown(KeyCode.JoystickButton4) ||  // Typically left shoulder button
               Input.GetKeyDown(KeyCode.JoystickButton5) ||  // Typically right shoulder button
               Input.GetKeyDown(KeyCode.JoystickButton6) ||  // Typically left stick click
               Input.GetKeyDown(KeyCode.JoystickButton7) ||  // Typically right stick click
               Input.GetKeyDown(KeyCode.JoystickButton8) ||  // Often start button
               Input.GetKeyDown(KeyCode.JoystickButton9) ||  // Often back/select button
               Input.GetKeyDown(KeyCode.JoystickButton10) || // Sometimes left controller menu
               Input.GetKeyDown(KeyCode.JoystickButton11) || // Sometimes right controller menu
               Input.GetKeyDown(KeyCode.JoystickButton12) || // Extra buttons
               Input.GetKeyDown(KeyCode.JoystickButton13) ||
               Input.GetKeyDown(KeyCode.JoystickButton14) ||
               Input.GetKeyDown(KeyCode.JoystickButton15) ||
               Input.GetKeyDown(KeyCode.JoystickButton16) ||
               Input.GetKeyDown(KeyCode.JoystickButton17) ||
               Input.GetKeyDown(KeyCode.JoystickButton18) ||
               Input.GetKeyDown(KeyCode.JoystickButton19) ||
               Input.GetKeyDown(KeyCode.E); // Keyboard fallback
    }

    private void StartInteraction()
    {
        hasInteracted = true;
        interactionInProgress = true;
        interactUI.SetActive(false);
        guidingQPanel.SetActive(false);

        InteractionManager.Instance.StartInteraction(
            focusPoint,
            "The coral has turned white.\nWarming waters caused the coral to bleach and expel algae it depends on.",
            () =>
            {
                interactionInProgress = false;
                QuestManager2.Instance.CompleteQuest(4, interactUI);
                Debug.Log("Coral interaction completed");
            });
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasInteracted)
        {
            canInteract = true;
            guidingQPanel.SetActive(true);
            Debug.Log("Player entered coral interaction zone");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
            guidingQPanel.SetActive(false);
            Debug.Log("Player exited coral interaction zone");
        }
    }

    public void ResetInteraction()
    {
        canInteract = false;
        hasInteracted = false;
        interactionInProgress = false;
        interactUI.SetActive(true);
        guidingQPanel.SetActive(false);
        Debug.Log("Coral interaction reset");
    }

    // Optional visual feedback
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && canInteract && !hasInteracted)
        {
            // Add visual pulse or highlight effect here if desired
        }
    }
}
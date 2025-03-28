using UnityEngine;

public class SquidDialogue2 : MonoBehaviour
{
    public GameObject dialogueUI;  // UI for the dialogue
    public GameObject interactUI;  // UI for "!"
    public TMPro.TextMeshProUGUI dialogueText;
    public GameObject questUI;     // Reference to the quest panel

    private bool canInteract = false;
    private bool hasInteracted = false;

    private void Start()
    {
        dialogueUI.SetActive(false);  // Hide dialogue UI
        interactUI.SetActive(true);   // Show "!" initially
    }

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E) && !hasInteracted)
        {
            ShowDialogue();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
        }
    }

    void ShowDialogue()
    {
        interactUI.SetActive(false);  // Hide "!"
        dialogueUI.SetActive(true);   // Show dialogue
        dialogueText.text = "Uhh...I can't breath."; // Set dialogue text

        hasInteracted = true;

        // Mark quest as completed (if applicable)
        if (questUI != null)
        {
            questUI.SetActive(true);
            Debug.Log("Quest Updated: Squid interaction complete.");
        }

        // Hide dialogue and bring back "!" after 3 seconds
        Invoke("HideDialogue", 3f);
    }

    void HideDialogue()
    {
        dialogueUI.SetActive(false);  // Hide dialogue
        interactUI.SetActive(true);   // Show "!" again
        hasInteracted = false;        // Allow re-interaction
    }
}

using UnityEngine;

public class MusselInteraction : MonoBehaviour
{
    public GameObject interactUI;
    public Transform focusPoint; // Empty GameObject to focus camera
    private bool canInteract = false;
    private bool hasInteracted = false;
    private bool interactionInProgress = false;

    void Start() { interactUI.SetActive(true); }

    void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E) && !hasInteracted && !interactionInProgress)
        {
            hasInteracted = true;
            interactionInProgress = true;
            interactUI.SetActive(false);

            InteractionManager.Instance.StartInteraction(
                focusPoint,
                "Oysters and mussels build their shells using calcium carbonate. Ocean acidification weakens their shells, making them vulnerable.",
                () => {
                    interactionInProgress = false;
                    QuestManager.Instance.CompleteQuest(3, interactUI); // Quest ID 3
                });
        }
    }

    private void OnTriggerEnter(Collider other) { if (other.CompareTag("Player")) canInteract = true; }
    private void OnTriggerExit(Collider other) { canInteract = false; }
}

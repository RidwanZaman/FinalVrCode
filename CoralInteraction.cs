using UnityEngine;

public class CoralInteraction : MonoBehaviour
{
    public GameObject interactUI;
    public Transform focusPoint; // Empty GameObject to focus camera
    private bool canInteract = false;
    private bool hasInteracted = false;
    private bool interactionInProgress = false;

    void Start()
    {
        interactUI.SetActive(true);
    }

    void Update()
    {
        if (canInteract && !hasInteracted && !interactionInProgress &&
            (Input.GetKeyDown(KeyCode.JoystickButton4) || Input.GetKeyDown(KeyCode.JoystickButton5) || Input.GetKeyDown(KeyCode.E)))
        {
            hasInteracted = true;
            interactionInProgress = true;
            interactUI.SetActive(false);

            InteractionManager.Instance.StartInteraction(
                focusPoint,
                "Coral reefs support marine biodiversity. Warming oceans cause coral bleaching, threatening countless marine species.",
                () =>
                {
                    interactionInProgress = false;
                    QuestManager.Instance.CompleteQuest(4, interactUI); // Quest ID 4
                });
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasInteracted)
        {
            canInteract = true;
            interactUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
            interactUI.SetActive(false);
        }
    }
}

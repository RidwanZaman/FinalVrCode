using UnityEngine;

public class KelpInteraction : MonoBehaviour
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
                "HELP!! My statoliths are disfunctional! statoliths usally help me orient my body properly but because of the increase in ocean acidification, I couldn't produce them properly so now I'm stuck like this!",
                () => {
                    interactionInProgress = false;
                    QuestManager.Instance.CompleteQuest(6, interactUI); // Quest ID 6
                });
        }
    }

    private void OnTriggerEnter(Collider other) { if (other.CompareTag("Player")) canInteract = true; }
    private void OnTriggerExit(Collider other) { canInteract = false; }
}

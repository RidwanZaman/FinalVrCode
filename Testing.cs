using UnityEngine;

public class Testing : MonoBehaviour
{
   
  
    public Transform focusPoint;
    private bool canInteract = false;
    private bool hasInteracted = false;
    private bool interactionInProgress = false;

    void Start()

    { }

    void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E) && !hasInteracted && !interactionInProgress)
        {
            hasInteracted = true;
            interactionInProgress = true;
            
            

            // Start interaction sequence
            InteractionManager.Instance.StartInteraction(
                focusPoint,
                "Sea stars help control sea urchin populations, keeping kelp forests healthy.",
                () =>
                {
                    interactionInProgress = false;

                    //  Final disable - even if player re-enters trigger
                });
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasInteracted)
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
}

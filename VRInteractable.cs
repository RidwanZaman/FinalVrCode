using UnityEngine;
using UnityEngine.XR;
using System.Collections.Generic;

public class VRInteractable : MonoBehaviour
{
    [Header("VR Interaction Settings")]
    public GameObject interactUI;
    public Transform focusPoint;
    protected bool canInteract = false;
    protected bool hasInteracted = false;
    protected bool interactionInProgress = false;

    protected virtual void Start()
    {
        if (interactUI != null)
            interactUI.SetActive(true);
    }

    protected virtual void Update()
    {
        if (canInteract && !hasInteracted && !interactionInProgress)
        {
            // Check ALL VR controllers for trigger press
            var inputDevices = new List<InputDevice>();
            InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Controller, inputDevices);

            foreach (var device in inputDevices)
            {
                if (device.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerPressed) && triggerPressed)
                {
                    StartInteraction();
                    break;
                }
            }
        }
    }

    protected virtual void StartInteraction()
    {
        hasInteracted = true;
        interactionInProgress = true;

        if (interactUI != null)
            interactUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = true;
            Debug.Log("Can interact with " + gameObject.name);
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
using UnityEngine;
using TMPro;
using System.Collections;

public class InteractionManager : MonoBehaviour
{
    public static InteractionManager Instance;

    public Camera mainCamera;
    public float focusDuration = 3f;
    public float rotationSpeed = 2f;
    public TextMeshProUGUI dialogueText;
    public GameObject dialogueUI;
    public GameObject player;
    public float typingSpeed = 0.03f;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void StartInteraction(Transform focusTarget, string message, System.Action onComplete = null)
    {
        StartCoroutine(HandleInteraction(focusTarget, message, onComplete));
    }

    IEnumerator HandleInteraction(Transform focusTarget, string message, System.Action onComplete)
    {
        // Disable movement
        if (player.GetComponent<FirstPersonController>())
            player.GetComponent<FirstPersonController>().enabled = false;

        // Smooth camera rotate
        float timer = 0f;
        Vector3 targetDir = focusTarget.position - mainCamera.transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(targetDir);

        while (timer < focusDuration)
        {
            mainCamera.transform.rotation = Quaternion.Slerp(mainCamera.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
        }

        // Dialogue typewriter
        dialogueUI.SetActive(true);
        dialogueText.text = "";
        foreach (char letter in message.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        yield return new WaitForSeconds(1.5f); // Small delay to read


        // Re-enable movement
        if (player.GetComponent<FirstPersonController>())
            player.GetComponent<FirstPersonController>().enabled = true;

        // Optional callback (like marking quest complete)
        onComplete?.Invoke();
    }
}

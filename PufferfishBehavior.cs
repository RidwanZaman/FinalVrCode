using UnityEngine;
using System.Collections;

public class PufferfishBehavior : MonoBehaviour
{
    public GameObject smallPufferfish;
    public GameObject puffedUpPufferfish;
    public float puffDuration = 3f;
    private bool isPuffed = false;

    private void Start()
    {
        smallPufferfish.SetActive(true);
        puffedUpPufferfish.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isPuffed)
        {
            Debug.Log("Player entered pufferfish zone! Puffing up...");
            StartCoroutine(PuffUp());
        }
    }

    IEnumerator PuffUp()
    {
        isPuffed = true;

        // Instead of deactivating, swap visibility
        smallPufferfish.GetComponent<MeshRenderer>().enabled = false;
        puffedUpPufferfish.SetActive(true);
        Debug.Log("Pufferfish is now puffed up!");

        yield return new WaitForSeconds(puffDuration);

        puffedUpPufferfish.SetActive(false);
        smallPufferfish.GetComponent<MeshRenderer>().enabled = true;
        Debug.Log("Pufferfish returned to normal.");

        isPuffed = false;
    }
}

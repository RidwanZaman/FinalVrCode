using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure camera has "MainCamera" tag
        {
            SceneManager.LoadScene("Scene00"); // Replace with your scene name
        }
    }
}

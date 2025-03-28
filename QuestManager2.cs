using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections; // Add this for IEnumerator!

public class QuestManager2 : MonoBehaviour
{
    public static QuestManager2 Instance;
    public TextMeshProUGUI questText;
    public TextMeshProUGUI dataText;
    public GameObject dataPanel;
    public GameObject SceneTransition;
    private int currentQuestIndex = 0;

    private string[] quests =
    {
        "Find and interact with the Sea Urchins.",
        "Interact with the kelp.",
        "Interact with the Jellyfish swarm.",
        "Tap on the Mussel to see the effect.",
        "Examine the Coral and its bleached state.",
        "Quests Complete, transitioning soon"
    };

    private string[] questData =
    {
        "**Info will show here**",
        "**Sea Urchins & Overpopulation**\nThe unchecked proliferation of purple sea urchins has led to the decimation of over 90% of kelp forests in certain regions, transforming them into 'urchin barrens' and causing significant habitat loss.",
        "**Squids is lost**\nOcean acidification negatively impacts squids by affecting their development, size, statoliths (which help with orientation), and potentially their ability to swim, leading to smaller, slower, and possibly malformed squid.",
        "**Jellyfish Overgrowth**\n\"In 2025, Scottish salmon farms suffered significant losses, with over 200,000 farmed salmon killed due to jellyfish stings. This incident underscores the vulnerability of aquaculture to jellyfish overpopulation.",
        "**Mussels & Ocean Acidification**\nOcean acidification reduces the availability of carbonate ions, essential for mussels to build and maintain their calcium carbonate shells, thereby increasing their vulnerability.",
        "**Coral Bleaching**\nCoral bleaching not only affects the corals themselves but also the myriad marine species that rely on coral reefs for shelter and sustenance, leading to broader ecosystem disruptions."
    };

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        dataPanel.SetActive(true);
        questText.text = quests[currentQuestIndex];
        dataText.text = questData[currentQuestIndex];
    }

    public void CompleteQuest(int questIndex, GameObject interactUI)
    {
        if (questIndex == currentQuestIndex)
        {
            interactUI.SetActive(false);
            StartCoroutine(AdvanceQuest()); // Start coroutine here!
        }
    }

    IEnumerator AdvanceQuest() // Now a coroutine!
    {
        currentQuestIndex++;
        FindObjectOfType<ArrowManager>().UpdateArrowTarget(currentQuestIndex);
        questText.text = quests[currentQuestIndex];
        dataText.text = questData[currentQuestIndex];
        if (currentQuestIndex == quests.Length-1)
        {
            yield return new WaitForSeconds(10f);
            SceneTransition.SetActive(true);
        }
       
    }
}

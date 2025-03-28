using UnityEngine;
using UnityEngine.UI;

public class MultiSliderManager : MonoBehaviour
{
    public Slider slider1;
    public Slider slider2;
    public Slider slider3;
    private int[] surveyResults = new int[3];  // Stores answers

    public void ConfirmValues()
    {
        surveyResults[0] = (int)slider1.value;
        surveyResults[1] = (int)slider2.value;
        surveyResults[2] = (int)slider3.value;

        Debug.Log($"Survey Results: {surveyResults[0]}, {surveyResults[1]}, {surveyResults[2]}");

        // Notify JellyfishGuide that the survey is complete
        JellyfishGuide.Instance.CompleteSurvey();
    }
}
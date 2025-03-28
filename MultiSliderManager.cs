using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class MultiSliderManage : MonoBehaviour
{
    public Slider slider1;
    public Slider slider2;
    public Slider slider3;

    public TMP_Text display1;
    public TMP_Text display2;
    public TMP_Text display3;

    private string filePath;

    void Start()
    {
#if UNITY_EDITOR
        // Save inside Assets/SaveData when running in the Editor
        string directory = Application.dataPath + "/SaveData";
#else
        // Save to persistent data path when running a build
        string directory = Application.persistentDataPath + "/SaveData";
#endif
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        filePath = Path.Combine(directory, "sliderDatas.json");

        LoadFromFile(); // Load saved values at the start
        UpdateDisplay(); // Refresh the display with loaded data
    }

    void Update()
    {
        // Live update displays as slider values change
        UpdateDisplay();
    }

    // ✅ Display values on screen
    private void UpdateDisplay()
    {
        display1.text = "Value 1: " + slider1.value.ToString("F1");
        display2.text = "Value 2: " + slider2.value.ToString("F1");
        display3.text = "Value 3: " + slider3.value.ToString("F1");
    }

    // ✅ Called by Confirm Button to save data
    public void ConfirmValues()
    {
        SliderDatas data = new SliderDatas
        {
            slider1Value = slider1.value,
            slider2Value = slider2.value,
            slider3Value = slider3.value
        };

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(filePath, json);
        Debug.Log("Saved slider values to file: " + filePath);
    }

    // ✅ Load saved data on startup
    private void LoadFromFile()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            SliderDatas data = JsonUtility.FromJson<SliderDatas>(json);

            slider1.value = data.slider1Value;
            slider2.value = data.slider2Value;
            slider3.value = data.slider3Value;

            Debug.Log("Loaded slider values from file: " + filePath);
        }
        else
        {
            Debug.Log("No save file found, using default values.");
        }
    }
}

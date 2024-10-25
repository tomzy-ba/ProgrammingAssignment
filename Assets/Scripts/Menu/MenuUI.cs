using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public Slider sensSlider;
    public InputField nameInput;

    public Text level1Time;
    public Text level2Time;
    public Text level3Time;
    public Text level4Time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadSettings();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnLevel1Button()
    {
        SaveSettings();
        SceneManager.LoadScene("Level1");
    }
    public void OnLevel2Button()
    {
        SaveSettings();
        SceneManager.LoadScene("Level2");
    }  
    public void OnLevel3Button()
    {
        SaveSettings();
        SceneManager.LoadScene("Level3");
    }
    public void OnLevel4Button()
    {
        SaveSettings();
        SceneManager.LoadScene("Level4");
    }

    void SaveSettings()
    {
        // converts the sensitivity
        PlayerPrefs.SetFloat("Sensitivity", sensSlider.value);
        string playerName = nameInput.text;
        PlayerPrefs.SetString("PlayerName", playerName);
    }

    void LoadSettings()
    {
        // gets playerprefs sensitivity value and assigns it to the slider
        sensSlider.value = PlayerPrefs.GetFloat("Sensitivity", 0);
        nameInput.text = PlayerPrefs.GetString("PlayerName", "");

        // gets the playerprefs player name value and level 1 time value and concats them, then assigns to level1timetext
        level1Time.text = PlayerPrefs.GetString("PlayerName", "not completed") + " " + PlayerPrefs.GetFloat("Level1Time");
        level2Time.text = PlayerPrefs.GetString("PlayerName", "not completed") + " " + PlayerPrefs.GetFloat("Level2Time");
        level3Time.text = PlayerPrefs.GetString("PlayerName", "not completed") + " " + PlayerPrefs.GetFloat("Level3Time");

    }
}

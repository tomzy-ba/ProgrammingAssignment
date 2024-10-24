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
        int sens = Convert.ToInt32(sensSlider.value);
        PlayerPrefs.SetInt("Sensitivity", sens);
        string playerName = nameInput.text;
        PlayerPrefs.SetString("PlayerName", playerName);
    }

    void LoadSettings()
    {
        sensSlider.value = PlayerPrefs.GetInt("Sensitivity", 0);
        nameInput.text = PlayerPrefs.GetString("PlayerName", "");

        level1Time.text = PlayerPrefs.GetString("PlayerName", "not completed") + " " + PlayerPrefs.GetFloat("Level1Time");
        level2Time.text = PlayerPrefs.GetString("PlayerName", "not completed") + " " + PlayerPrefs.GetFloat("Level2Time");
        level2Time.text = PlayerPrefs.GetString("PlayerName", "not completed" + " " + PlayerPrefs.GetFloat("Level3Time"));
    }
}

using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public Slider sensSlider;
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
    }

    void LoadSettings()
    {
        sensSlider.value = PlayerPrefs.GetInt("Sensitivity", 0);
    }
}

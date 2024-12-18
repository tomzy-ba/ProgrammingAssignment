using System;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCreation : MonoBehaviour
{
    public InputField nameInput;
    public InputField maxHpInput;
    public InputField hpInput;
    public InputField moveSpeedInput;

    private string hello = "bruh";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hello = "HUH";
        Debug.Log("hello");
        TestSaveDataWithNegativeSpeed();
        LoadPlayerData();
    }

    public void SavePlayerData()
    {
        string playerName = nameInput.text;
        int maxHp = Convert.ToInt32(maxHpInput.text);
        int hp = Convert.ToInt32(hpInput.text);
        float moveSpeed = float.Parse(moveSpeedInput.text);
        PlayerData playerData = new PlayerData(playerName, maxHp, hp, moveSpeed);
        SaveSystem.SavePlayer(playerData);
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadPlayerData() {
        PlayerData playerData = SaveSystem.LoadPlayer();
        nameInput.text = playerData.playerName;
        maxHpInput.text = Convert.ToString(playerData.maxHp);
        hpInput.text = Convert.ToString(playerData.hp);
        moveSpeedInput.text = Convert.ToString(playerData.moveSpeed);
    }


    // unit testing
    public void TestSaveDataWithNegativeHealth() {
        PlayerData playerData = new PlayerData("tom", -100, -100, 15);
        Debug.Log("hello");
        SaveSystem.SavePlayer(playerData);
    }
    public void TestSaveDataWithNegativeSpeed() {
        Debug.Log("HELLO");
        PlayerData playerData = new PlayerData("tom", 100, 100, -10f);

        SaveSystem.SavePlayer(playerData);
    }
    public void TestSaveDataWithInvalidString() {
        PlayerData playerData = new PlayerData("", 100, 100, 15);

        SaveSystem.SavePlayer(playerData);
    }
}

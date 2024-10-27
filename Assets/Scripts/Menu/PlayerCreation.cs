using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCreation : MonoBehaviour
{
    public InputField nameInput;
    public InputField maxHpInput;
    public InputField hpInput;
    public InputField moveSpeedInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
        SceneManager.LoadScene("Level1");
    }

    public void LoadPlayerData() {
        PlayerData playerData = SaveSystem.LoadPlayer();
        nameInput.text = playerData.playerName;
        maxHpInput.text = Convert.ToString(playerData.maxHp);
        hpInput.text = Convert.ToString(playerData.hp);
        moveSpeedInput.text = Convert.ToString(playerData.moveSpeed);
    }
}

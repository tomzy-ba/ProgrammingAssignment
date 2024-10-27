using System;
using UnityEngine;
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
        
    }

    public void CreatePlayer()
    {
        Player player = new Player();
        string name = nameInput.text;
        int maxHp = Convert.ToInt32(maxHpInput.text);
        int hp = Convert.ToInt32(hpInput.text);
        float moveSpeed = (float) Convert.ToDouble(moveSpeedInput.text);
        player.SetName(name);
        player.SetMaxHp(maxHp);
        player.SetHp(hp);
        player.SetMoveSpeed(moveSpeed);
        SaveSystem.SavePlayer(player);
    }

}

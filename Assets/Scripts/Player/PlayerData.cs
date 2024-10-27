using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string playerName;
    public int maxHp;
    public int hp;
    public float moveSpeed;


    public PlayerData(string playerName, int maxHp, int hp, float moveSpeed)
    {
        this.playerName = playerName;
        this.maxHp = maxHp;
        this.hp = hp;
        this.moveSpeed = moveSpeed;
    }
}

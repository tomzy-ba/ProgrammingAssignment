using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string playerName;
    public int maxHp;
    public int hp;
    public float moveSpeed;

    public PlayerData(Player player)
    {
        playerName = player.GetName();
        maxHp = player.GetMaxHp();
        hp = player.GetHp();
        moveSpeed = player.GetMoveSpeed();
    }
}

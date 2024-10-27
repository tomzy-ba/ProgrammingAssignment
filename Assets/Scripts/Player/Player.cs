using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private string playerName;
    [SerializeField]
    private int maxHp;
    [SerializeField]
    private int hp;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float jumpForce;


    public void MultiSpeed(float multi)
    {
        moveSpeed *= multi;
    }
    public void SetName(string name)
    {
        playerName = name;
    }
    public string GetName()
    {
        return playerName;
    }
    public int GetMaxHp()
    {
        return maxHp;
    }
    public int GetHp()
    {
        return hp;
    }

    public void SetHp(int newHp)
    {
        hp = newHp;
    }
    public void SetMaxHp(int newMaxHp)
    {
        maxHp = newMaxHp;
    }

    public void SetMoveSpeed(float newMoveSpeed)
    {
        moveSpeed = newMoveSpeed;
    }

    public bool TakeDamage(int damage)
    {
        Debug.Log("Player takes " + damage + "damage");
        // same as hp = hp - damage
        hp -= damage;
        if (hp <= 0)
        {
            Debug.Log("PLAYER DEAD");
            Die();
            return true;
        }
        return false;
    }

    public void Die()
    {
        Debug.Log("PLAYER DEAD");
        SceneManager.LoadScene("MainMenu");
    }

    public void Heal(int health)
    {
        Debug.Log("Player heals for " + health + "health");
        hp += health;
        if (hp > maxHp)
        {
            hp = maxHp;
        }
    }
    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
    public float GetJumpForce()
    {
        return jumpForce;
    }
}

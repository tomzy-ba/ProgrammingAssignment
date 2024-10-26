using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int maxHp;
    [SerializeField]
    private int hp;
    [SerializeField]
    private float moveSpeed;


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

    public bool TakeDamage(int damage)
    {
        Debug.Log("Player takes " + damage + "damage");
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
}

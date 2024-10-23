using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int maxHp;
    public int hp;

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
        SceneManager.LoadScene("SampleScene");
    }
}

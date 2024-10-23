using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Slider hpSlider;
    public Text hpText;
    public GameObject playerPrefab;

    private void Start()
    {
    }
    private void Update()
    {
    }
    public void UpdateUI(Player player)
    {
        hpSlider.maxValue = player.maxHp;
        hpSlider.value = player.hp;
        hpText.text = $"HP {player.hp}/{player.maxHp}";
    }

}

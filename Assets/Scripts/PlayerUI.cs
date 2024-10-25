using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Slider hpSlider;
    public Text hpText;
    public GameObject playerPrefab;
    public GameObject bloodSplatter;

    private void Start()
    {
    }
    private void Update()
    {
    }
    public void UpdateUI(Player player)
    {
        if (hpSlider.value > player.GetHp())
        {
            StartCoroutine(TakeDamageUI());
        }
        hpSlider.maxValue = player.GetMaxHp();
        hpSlider.value = player.GetHp();
        hpText.text = $"HP {player.GetHp()}/{player.GetMaxHp()}";
    }

    private IEnumerator TakeDamageUI()
    {
        bloodSplatter.SetActive(true);
        yield return new WaitForSeconds(1f);
        bloodSplatter.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatusUI : MonoBehaviour
{
    [Header("공격력")]
    public TextMeshProUGUI attackTxt;

    [Header("방어력")]
    public TextMeshProUGUI defenseTxt;

    [Header("체력")]
    public TextMeshProUGUI healthTxt;

    [Header("치명타율")]
    public TextMeshProUGUI critical;


    public void ShowStats()
    {
        attackTxt.text = GameManager.Instance.player.Stats.attack.ToString();
        defenseTxt.text = GameManager.Instance.player.Stats.defense.ToString();
        healthTxt.text = GameManager.Instance.player.Stats.health.ToString();
        critical.text = GameManager.Instance.player.Stats.critical.ToString();
    }
}

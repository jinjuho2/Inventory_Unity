using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatusUI : MonoBehaviour
{
    [Header("���ݷ�")]
    public TextMeshProUGUI attackTxt;

    [Header("����")]
    public TextMeshProUGUI defenseTxt;

    [Header("ü��")]
    public TextMeshProUGUI healthTxt;

    [Header("ġ��Ÿ��")]
    public TextMeshProUGUI critical;


    public void ShowStats()
    {
        attackTxt.text = GameManager.Instance.player.Stats.attack.ToString();
        defenseTxt.text = GameManager.Instance.player.Stats.defense.ToString();
        healthTxt.text = GameManager.Instance.player.Stats.health.ToString();
        critical.text = GameManager.Instance.player.Stats.critical.ToString();
    }
}

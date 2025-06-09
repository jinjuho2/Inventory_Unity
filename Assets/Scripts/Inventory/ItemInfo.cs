using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    public ItemSlot itemSlot;
    [SerializeField]
    private TextMeshProUGUI name;
    [SerializeField]
    private TextMeshProUGUI attack;
    [SerializeField]
    private TextMeshProUGUI defense;
    [SerializeField]
    private TextMeshProUGUI health;
    [SerializeField]
    private TextMeshProUGUI critical;

    public void SetInfo(ItemSlot slot)
    {
        if (slot == null || slot.itemData == null)
        {
            name.text = "";
            attack.text = "0";
            defense.text = "0";
            health.text = "0";
            critical.text = "0";
            return;
        }
        name.text = slot.itemData?._name;
        attack.text = slot.itemData?.attack.ToString();
        defense.text = slot.itemData?.defense.ToString();
        health.text = slot.itemData?.health.ToString();
        critical.text = slot.itemData?.critical.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    public Transform inventoryPanel;
    public ItemSlot[] slots;
    private int hasItemCount = 0;

    [SerializeField]
    private Transform donthavetoKnow;

    public TextMeshProUGUI slotCount;

    private void Update()
    {
        hasItemCount = 0;
        slots = inventoryPanel.GetComponentsInChildren<ItemSlot>();

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].index = i;
        }

        foreach (ItemSlot slot in slots)
        {
            if (slot.HasItemData())
            {
                hasItemCount++;
                slot.SetSlot();
                slot.icon.transform.SetParent(donthavetoKnow, true);
            }

        }
        slotCount.text = $"Inventory {hasItemCount} / {slots.Length}";
    }

}

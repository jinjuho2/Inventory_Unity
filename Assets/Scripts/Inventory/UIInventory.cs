using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class UIInventory : MonoBehaviour
{
    public Transform inventoryPanel;
    public ItemSlot[] slots;
    private int hasItemCount = 0;

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
            }

        }
        slotCount.text = $"Inventory {hasItemCount} / {slots.Length}";
    }

}

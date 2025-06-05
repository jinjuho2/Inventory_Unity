using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField]
    private Image icon;
    [SerializeField]
    private Image isEquip;

    public int index;

    public ItemData itemData;

    public bool HasItemData()
    {
        return itemData != null;
    }

    public void Clear()
    {
        itemData.isEquipped = false;
        itemData = null;
        icon.enabled = false;
        isEquip.enabled = false;
        
    }

    public void SetSlot()
    {
        icon.sprite = itemData.icon;
        icon.enabled = true;
        isEquip.enabled = itemData?.isEquipped ?? false;
    }

}

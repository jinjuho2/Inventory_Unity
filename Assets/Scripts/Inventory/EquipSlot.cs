using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquipSlot : MonoBehaviour, IPointerClickHandler
{
    public ItemSlot itemSlot;

    public void OnPointerClick(PointerEventData eventData)
    {
        itemSlot.itemData.isEquipped = !itemSlot.itemData.isEquipped;

        itemSlot.isEquipped.text = itemSlot.itemData.isEquipped ? "«ÿ¡¶" : "¿Â¬¯";

        GameManager.Instance.UpdateStat(itemSlot.itemData);
    }
}

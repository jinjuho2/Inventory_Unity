using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Net.NetworkInformation;
using TMPro;

public class ItemSlot : MonoBehaviour,
    IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler,
    IEndDragHandler, IDragHandler, IPointerClickHandler
{
    [SerializeField]
    private ItemInfo itemInfo;

    [SerializeField]
    private Image icon;
    [SerializeField]
    private Image isEquip;

    [SerializeField]
    private Image background;

    public TextMeshProUGUI isEquipped;

    public int index;

    public ItemData itemData;

    private Color color;

    private Vector3 originVec;

    [SerializeField]
    private EquipSlot equipSlot;

    



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

    public void OnPointerEnter(PointerEventData eventData)
    {
        color = background.color;

        itemInfo.SetInfo(this);

        background.color = Color.magenta;

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        background.color = color;

        itemInfo.SetInfo(null);


    }

    public void OnPointerClick(PointerEventData eventData)
    {
        isEquipped.text = itemData.isEquipped ? "«ÿ¡¶" : "¿Â¬¯";

        equipSlot.itemSlot = this;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //originVec = icon.transform.localPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Vector3 mousePos = Input.mousePosition;
        //icon.transform.localPosition += mousePos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

    }

}

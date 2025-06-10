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
    [Header("UI")]
    [SerializeField]
    private Image background;
    [SerializeField]
    private Image icon;
    [SerializeField]
    private Image isEquip;

    [Header("Others")]
    [SerializeField]
    private ItemInfo itemInfo;
    [SerializeField]
    private EquipSlot equipSlot;
    public TextMeshProUGUI isEquipped;



    [Header("Data")]
    public int index;
    public ItemData itemData;

    private Color color;
    private Vector3 originVec;

    public bool HasItemData() // ������ ���Կ� ������ �����Ͱ� �ִ��� Ȯ���մϴ�.
    {
        return itemData != null;
    }

    public void Clear() // ������ ������ ���ϴ�.
    {
        itemData.isEquipped = false;
        itemData = null;
        icon.enabled = false;
        isEquip.enabled = false;

    }

    public void SetSlot()    // ������ ���Կ� ������ �����͸� �����մϴ�.
    {
        icon.sprite = itemData?.icon;
        icon.enabled = itemData ? true : false;
        isEquip.enabled = itemData?.isEquipped ?? false;
    }

    public void OnPointerEnter(PointerEventData eventData) // ���콺 �����Ͱ� ������ ���� ���� �ö��� ���� ������ �����մϴ�.
    {
        color = background.color;

        itemInfo.SetInfo(this);

        background.color = Color.magenta;

    }

    public void OnPointerExit(PointerEventData eventData) // ���콺 �����Ͱ� ������ ���Կ��� ����� ���� ������ �����մϴ�.
    {
        background.color = color;

        itemInfo.SetInfo(null);
    }

    public void OnPointerClick(PointerEventData eventData)       // ������ ������ Ŭ������ ���� ������ �����մϴ�.
    {
        if(itemData == null)
            return;
        isEquipped.text = itemData.isEquipped ? "����" : "����";

        equipSlot.itemSlot = this;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {                                                                //�Ʒ��� �������� �巡���� ���� ������ �����մϴ�.
        originVec = icon.transform.position;
    }                                                              

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePos = Input.mousePosition;
        icon.transform.position = mousePos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GameObject target = eventData.pointerCurrentRaycast.gameObject;

        if (target == null)
        {
            icon.transform.position = originVec;
            return;
        }

        ItemSlot targetSlot = target.GetComponent<ItemSlot>();
        if (targetSlot == null)
        {
            icon.transform.position = originVec;
            return;
        }

        if (targetSlot.itemData == null)
        {
            targetSlot.itemData = itemData;
            itemData = null;

            SetSlot();           
            targetSlot.SetSlot();
            icon.transform.position = originVec;
        }
        else
        {
            icon.transform.position = originVec;
        }
    }


}

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

    public bool HasItemData() // 아이템 슬롯에 아이템 데이터가 있는지 확인합니다.
    {
        return itemData != null;
    }

    public void Clear() // 아이템 슬롯을 비웁니다.
    {
        itemData.isEquipped = false;
        itemData = null;
        icon.enabled = false;
        isEquip.enabled = false;

    }

    public void SetSlot()    // 아이템 슬롯에 아이템 데이터를 설정합니다.
    {
        icon.sprite = itemData?.icon;
        icon.enabled = itemData ? true : false;
        isEquip.enabled = itemData?.isEquipped ?? false;
    }

    public void OnPointerEnter(PointerEventData eventData) // 마우스 포인터가 아이템 슬롯 위에 올라갔을 때의 동작을 정의합니다.
    {
        color = background.color;

        itemInfo.SetInfo(this);

        background.color = Color.magenta;

    }

    public void OnPointerExit(PointerEventData eventData) // 마우스 포인터가 아이템 슬롯에서 벗어났을 때의 동작을 정의합니다.
    {
        background.color = color;

        itemInfo.SetInfo(null);
    }

    public void OnPointerClick(PointerEventData eventData)       // 아이템 슬롯을 클릭했을 때의 동작을 정의합니다.
    {
        if(itemData == null)
            return;
        isEquipped.text = itemData.isEquipped ? "해제" : "장착";

        equipSlot.itemSlot = this;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {                                                                //아래는 아이템을 드래그할 때의 동작을 정의합니다.
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

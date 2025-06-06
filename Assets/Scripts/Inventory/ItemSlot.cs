using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Net.NetworkInformation;

public class ItemSlot : MonoBehaviour , IPointerEnterHandler , IPointerExitHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField]
    private Image icon;
    [SerializeField]
    private Image isEquip;

    [SerializeField]
    private Image background;

    public int index;

    public ItemData itemData;

    private Color color;

    private Vector3 originVec;

    

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
        
        if (background != null)
        {
            //background.color = new Color32(207, 255, 0, 255);
            background.color = Color.magenta;
        }
        else
        {
            Debug.LogWarning("background 이미지가 연결되지 않았습니다!");
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        background.color = color;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originVec = icon.transform.localPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePos = Input.mousePosition;
        icon.transform.localPosition += mousePos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
    }

}

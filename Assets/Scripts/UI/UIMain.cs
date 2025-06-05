using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMain : MonoBehaviour
{

    public Button status;
    public Button inventory;
    public GameObject inventoryImage;
    public GameObject statusImage;

    public void OnClickInventory()
    {
        status.gameObject.SetActive(false);
        inventory.gameObject.SetActive(false);
        inventoryImage.SetActive(true);
    }

    public void OnClickStatus()
    {
        inventory.gameObject.SetActive(false);
        status.gameObject.SetActive(false);
        statusImage.SetActive(true);
    }

    public void OnClickReset()
    {
        status.gameObject.SetActive(true);
        inventory.gameObject.SetActive(true);
        inventoryImage.SetActive(false);
        statusImage.SetActive(false);
    }
}

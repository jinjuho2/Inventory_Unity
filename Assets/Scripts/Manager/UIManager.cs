using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
    
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private GameObject UIInventory;
    [SerializeField] private GameObject UIStatus;
    [SerializeField] private GameObject UIMain;

    [SerializeField] private Button inventory;
    [SerializeField] private Button status;

    private UIStatus UIstatus;

    private bool isOn = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        Init();
    }

    private void Init()
    {
        UIstatus = UIStatus.GetComponent<UIStatus>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && !isOn)
        {
            isOn = true;
            UIMain.SetActive(isOn);
        }
        else if (Input.GetKeyDown(KeyCode.I) && isOn)
        {
            isOn = false;
            UIMain.SetActive(isOn);
        }
    }

    

    public void OnClickInventory()
    {
        status.gameObject.SetActive(false);
        inventory.gameObject.SetActive(false);
        UIInventory.SetActive(true);
    }

    public void OnClickStatus()
    {
        inventory.gameObject.SetActive(false);
        status.gameObject.SetActive(false);
        UIStatus.SetActive(true);
        UIstatus.ShowStats();

    }

    public void OnClickReset()
    {
        status.gameObject.SetActive(true);
        inventory.gameObject.SetActive(true);
        UIStatus.SetActive(false);
        UIInventory.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    #region Singleton
    public static UI_Manager instance;

    private void Awake()
    {
        if(instance!=null)
            Destroy(instance);
        else
            instance= this;
    }
    #endregion

    [Header("UI Menus")]
    [SerializeField] private GameObject _inventoryMenu;

    private void Start()
    {
        Switch(null);
    }
    private void Switch(GameObject menu)
    {
        
        for(int i=0;i<transform.childCount;i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        if (menu==null)
            return;
        menu.SetActive(true);
    }
    public void SwitchTo(GameObject menu)
    {
        if(menu.activeSelf && menu!=null)
            menu.SetActive(false);
        else
            Switch(menu);
    }
    public void ToggleInventory()
    {
        SwitchTo(_inventoryMenu);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
            ToggleInventory();
        if (Input.GetKeyDown(KeyCode.Escape))
            Switch(null);
    }

}

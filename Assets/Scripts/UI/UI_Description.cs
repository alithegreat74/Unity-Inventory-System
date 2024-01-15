using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Description : MonoBehaviour
{
    #region Singleton
    // Making this class a singleton so it can be accessible from any point in the game
    public static UI_Description instance;

    private void Awake()
    {
        if (instance!=null)
            Destroy(instance.gameObject);
        else
            instance= this;
    }
    #endregion

    [Header("UI Elements")]
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _itemName;
    [SerializeField] private TextMeshProUGUI _itemDescription;

    private void Start()
    {
        Deinitialize();
    }

    public void Initialize(ItemData data)
    {
        for (int i = 0; i<transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
        _image.sprite=data.itemImage;
        _itemName.text=data.itemName;
        _itemDescription.text=data.itemDescription;
    }
    public void Deinitialize()
    {
        _image.sprite=null;
        _itemName.text="";
        _itemDescription.text="";
        for (int i=0;i<transform.childCount;i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}

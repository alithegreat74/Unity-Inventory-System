using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_ItemSlot : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI _itemCount;
    [SerializeField] private Image _itemImage;
    private InventoryItem _item;
    private RectTransform _rect;
    private Canvas _canvas;
    private void OnEnable()
    {
        _rect = GetComponent<RectTransform>();
        Transform temp = transform;
        while (temp.GetComponent<Canvas>()==null)
        {
            temp=temp.parent;
        }
        _canvas = temp.GetComponent<Canvas>();
    }

    
    public void Initialize(InventoryItem item)
    {
        _itemCount.text=item.itemCount>1?item.itemCount.ToString():"";
        _itemImage.sprite=item.data.itemImage;
        _item = item;
    }



    public void OnPointerEnter(PointerEventData eventData)
    {
        UI_Description.instance.Initialize(_item.data);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UI_Description.instance.Deinitialize();
    }

    public void Click()
    {
        InventoryManager.instance.EquipItem(_item.data);
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_ItemSlot : MonoBehaviour
{
    #region Singleton

    #endregion

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI _itemCount;
    [SerializeField] private Image _itemImage;

    private InventoryItem _item;
    public void Initialize(InventoryItem item)
    {
        _itemCount.text=item.itemCount>1?item.itemCount.ToString():"";
        _itemImage.sprite=item.data.itemImage;
        _item = item;
    }
}

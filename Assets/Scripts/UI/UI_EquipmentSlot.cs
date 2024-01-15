using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_EquipmentSlot : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    [Header("UI Elements")]
    [SerializeField] private Image _image;
    private ItemData _data;

    private void OnEnable()
    {
        SetItemVisibility(false);
    }

    private void SetItemVisibility(bool set)
    {
        for (int i = 0; i<transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(set);
        }
        transform.gameObject.GetComponent<Button>().enabled= set;
    }

    public void SetInfo(ItemData data)
    {
        if (data==null)
        {
            SetItemVisibility(false);
            return;
        }
        SetItemVisibility(true);
        _data=data;
        _image.color=Color.white;
        _image.sprite= data.itemImage;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        UI_Description.instance.Initialize(_data);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UI_Description.instance.Deinitialize();
    }

    public void Click()
    {
        InventoryManager.instance.UnequipItem(_data);
    }
}

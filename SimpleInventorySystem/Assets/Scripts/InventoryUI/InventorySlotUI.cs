using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] 
    Image image;
    [SerializeField] 
    Text value;
    [SerializeField] 
    Text duration;
    [SerializeField]
    Text weight;

    RectTransform descriptionPanel;
    Text descriptionPanelText;

    InventoryItem invItem = null;

    int slotIndex = -1;

    ActiveItemsManager activeItemsManager;
    ShopItemsManager shopItemsManager;
    DropItemsManager dropItemsManager;

    void Awake()
    {
        activeItemsManager = GameObject.Find("GameManager").GetComponent<ActiveItemsManager>();
        shopItemsManager = GameObject.Find("GameManager").GetComponent<ShopItemsManager>();
        dropItemsManager = GameObject.Find("GameManager").GetComponent<DropItemsManager>();

        descriptionPanel = GameObject.Find("DescriptionPanel").GetComponent<RectTransform>();
        descriptionPanelText = descriptionPanel.GetComponentInChildren<Text>();
    }

    void Start()
    {
        slotIndex = transform.GetSiblingIndex();
        Clear();
    }

    void Update()
    {
        
    }

    public void Clear()
    {
        invItem = null;
        image.sprite = null;
        value.gameObject.SetActive(false);
        duration.gameObject.SetActive(false);
        weight.gameObject.SetActive(false);

        descriptionPanel.gameObject.SetActive(false);
    }

    public void SetItem(InventoryItem invItem)
    {
        this.invItem = invItem;
        Item item = invItem.GetItem();

        image.sprite = item.Icon;

        this.weight.text = invItem.GetWeight().ToString();
        this.weight.gameObject.SetActive(true);

        
        if (invItem.GetCurrentValue() >= 0)
        {
            this.value.text = invItem.GetCurrentValue().ToString();
            this.value.gameObject.SetActive(true);
        }

        if (invItem.GetCurrentDuration() > 0)
        {
            this.duration.text = invItem.GetCurrentDuration().ToString();
            this.duration.gameObject.SetActive(true);
        }
        
    }
    public void SetValue(int value)
    {
        this.value.text = value.ToString();
    }

    public void SetDuration(int duration)
    {
        this.duration.text = duration.ToString();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (invItem != null)
        {
            descriptionPanel.transform.position = transform.position;
            descriptionPanelText.text = $"{invItem.GetItem().name}: {invItem.GetItem().GetFullDescription()}";
            descriptionPanel.gameObject.SetActive(true);

            // Description panel resizing problem on changing text on runtime (https://forum.unity.com/threads/content-size-fitter-refresh-problem.498536/)(#7) ---
            LayoutRebuilder.ForceRebuildLayoutImmediate(descriptionPanel);
            // ---
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
        descriptionPanel.gameObject.SetActive(false);
        
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            activeItemsManager.UseItemByIndex(slotIndex);
        }
        else if(pointerEventData.button == PointerEventData.InputButton.Right)
        {
            shopItemsManager.SellItemByIndex(slotIndex);
        }
        else if (pointerEventData.button == PointerEventData.InputButton.Middle)
        {
            dropItemsManager.DropItemByIndex(slotIndex);
        }
    }
}

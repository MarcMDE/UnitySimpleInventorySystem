using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] 
    Image image;
    [SerializeField] 
    Text value;
    [SerializeField] 
    Text duration;
    [SerializeField]
    Text weight;
    [SerializeField]
    Text descriptionPanelText;
    [SerializeField]
    RectTransform descriptionPanel;

    InventoryItem invItem = null;


    void Start()
    {
        Clear();
    }

    void Update()
    {
        
    }

    public void Clear()
    {
        image.sprite = null;
        value.gameObject.SetActive(false);
        duration.gameObject.SetActive(false);
        weight.gameObject.SetActive(false);
    }

    public void SetItem(InventoryItem invItem)
    {
        this.invItem = invItem;
        Item item = invItem.GetItem();

        image.sprite = item.Icon;

        this.weight.text = item.Weight.ToString();
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
}

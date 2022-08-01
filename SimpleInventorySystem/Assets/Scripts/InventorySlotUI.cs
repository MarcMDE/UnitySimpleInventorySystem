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

    InventoryItem item = null;


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

    public void SetItem(InventoryItem item)
    {
        this.item = item;

        image.sprite = item.Icon;

        this.weight.text = item.Weight.ToString();
        this.weight.gameObject.SetActive(true);

        /*
        if (value != null)
        {
            this.value.text = value.ToString();
            this.value.gameObject.SetActive(true);
        }

        if (duration != null)
        {
            this.duration.text = duration.ToString();
            this.duration.gameObject.SetActive(true);
        }
        */
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
        if (item != null)
        {
            descriptionPanel.transform.position = transform.position;
            descriptionPanelText.text = $"{item.name}: {item.Description}";
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

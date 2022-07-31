using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    [SerializeField] 
    Image image;
    [SerializeField] 
    Text value;
    [SerializeField] 
    Text duration;


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
    }

    public void SetNewItem(Sprite icon, int? value=null, int? duration=null)
    {
        image.sprite = icon;

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
    }

    public void SetValue(int value)
    {
        this.value.text = value.ToString();
    }

    public void SetDuration(int duration)
    {
        this.duration.text = duration.ToString();
    }
}

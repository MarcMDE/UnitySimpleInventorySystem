using UnityEngine;

public class MainControls : MonoBehaviour
{
    [SerializeField] GameObject inventoryUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }
}

using UnityEngine;

public class MainControls : MonoBehaviour
{
    [SerializeField] GameObject inventoryUI;

    void Update()
    {
        // Show/Hide invenotry by pressing I
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }
}

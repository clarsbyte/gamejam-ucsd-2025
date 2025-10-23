using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIToggle : MonoBehaviour
{
    public InputSystemActions uiControls;

    [SerializeField]
    private GameObject healthUI;

    [SerializeField]
    private GameObject inventoryUI;

    [SerializeField]
    private GameObject backgroundUI;

    private InputAction triggerUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        uiControls = new InputSystemActions();
        healthUI.SetActive(false);
        inventoryUI.SetActive(false);
        backgroundUI.SetActive(false);
    }

    private void OnEnable()
    {
        triggerUI = uiControls.UI.Show;
        triggerUI.Enable();
    }

    private void OnDisable()
    {
        uiControls.Disable();
        triggerUI.Disable();
    }

    public void ShowHealthUI()
    {
        var wasPressed = triggerUI.triggered;

        if (wasPressed)
        {
            healthUI.SetActive(!healthUI.activeSelf);
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            backgroundUI.SetActive(!backgroundUI.activeSelf);
            Debug.Log("Toggling Heatlh UI");
        }
    }

    // Update is called once per frame
    void Update()
    {
        ShowHealthUI();
    }

    private void FixedUpdate() { }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionDetector : MonoBehaviour
{
    public GameObject interactIcon;
    private IInteractable interactableInRange = null;

    private InputSystemActions playerControls;

    [SerializeField]
    private GameObject ShrineView;

    private InputAction interact;

     private void Awake()
    {
        playerControls = new InputSystemActions();
    }

    private void OnEnable()
    {
        playerControls.Enable();

        interact = playerControls.Player.Interact;
        interact.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
        interact.Disable();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactIcon.SetActive(false);
        ShrineView.SetActive(false);
    }

    public void OnInteract(InputAction.CallbackContext context){
        if (context.performed){
            interactableInRange?.Interact();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(interact.WasPressedThisFrame()){
            interactableInRange?.Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.TryGetComponent(out IInteractable interactable)){
            interactIcon.SetActive(true);
            interactableInRange = interactable;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision){
        if(collision.TryGetComponent(out IInteractable interactable) && interactable == interactableInRange){
            interactIcon.SetActive(false);
            interactableInRange = null;

            //close shrine view when get too far from shrine
            ShrineView.SetActive(false);
        }
        
    }
}

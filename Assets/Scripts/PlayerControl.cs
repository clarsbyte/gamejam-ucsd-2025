using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    public float moveSpeed = 1F;

    private InputSystemActions playerControls;

    [SerializeField]
    private InputAction move;

    //health bar test
    private InputAction interact;
    //

    private Vector2 moveDirection = Vector2.zero;

    [SerializeField]
    private SpriteRenderer spriteRender;

    [SerializeField]
    private Animator animator;

    //Healthbar
    public HealthBar healthBar;
    public int maxHealth = 20;
    public int currentHealth;
    //

    private void Awake()
    {
        playerControls = new InputSystemActions();

        //health
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
        //
    }

    private void OnEnable()
    {
        playerControls.Enable();

        move = playerControls.Player.Move;
        move.Enable();

        //test health
        interact = playerControls.Player.Interact;
        interact.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();

        move.Disable();

        interact.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = move.ReadValue<Vector2>();

        rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        if (rb.linearVelocity != Vector2.zero)
            animator.SetBool("running", true);
        else
            animator.SetBool("running", false);

        if (rb.linearVelocityX != 0)
            spriteRender.flipX = rb.linearVelocityX < 0;

        //health
        var wasPressed = interact.triggered;
        if(interact.WasPressedThisFrame()){
            takeDamage(1);
            Debug.Log("take dmg");
        }
        
    }

    //takedamage
    void takeDamage(int dmg){
        currentHealth-=dmg;
        healthBar.setHealth(currentHealth);
    }

}

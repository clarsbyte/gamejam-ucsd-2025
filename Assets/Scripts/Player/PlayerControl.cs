using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    // For the physics/movement of the player
    [SerializeField]
    private Rigidbody2D rb;

    public float moveSpeed = 1F;

    // Everything related to player input
    private InputSystemActions playerControls;

    private InputAction move;
    private Vector2 moveDirection = Vector2.zero;

    private InputAction attack;

    // Everything related to player visuals
    [SerializeField]
    private SpriteRenderer spriteRender;

    [SerializeField]
    private Animator animator;

    // Runs before initialization
    private void Awake()
    {
        playerControls = new InputSystemActions();
    }

    // Enables/tracks the inputs
    private void OnEnable()
    {
        playerControls.Enable();

        move = playerControls.Player.Move;
        move.Enable();

        attack = playerControls.Player.Attack;
        attack.Enable();
    }

    // Disables the inputs
    private void OnDisable()
    {
        playerControls.Disable();

        move.Disable();
        attack.Disable();
    }

    private void playerMove()
    {
        moveDirection = move.ReadValue<Vector2>();

        rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        if (rb.linearVelocity != Vector2.zero)
            animator.SetBool("walking", true);
        else
            animator.SetBool("walking", false);

        if (rb.linearVelocityX != 0)
        {
            animator.SetBool("horizontal", true);

            animator.SetBool("up", false);
            animator.SetBool("down", false);

            spriteRender.flipX = rb.linearVelocityX < 0;
        }
        else if (rb.linearVelocityY > 0)
        {
            animator.SetBool("up", true);

            animator.SetBool("horizontal", false);
            animator.SetBool("down", false);
        }
        else
        {
            animator.SetBool("down", true);

            animator.SetBool("horizontal", false);
            animator.SetBool("up", false);
        }
    }

    private void playerAttack()
    {
        Debug.Log("Starting animation");
    }

    private void eventAnimationFunctionStart()
    {
        Debug.Log("Starting animation");
    }

    private void eventAnimationFunctionEnd()
    {
        Debug.Log("Ending animation");
    }

    // Update is called once per frame
    void Update()
    {
        playerMove();
        // playerAttack();

        if (attack.triggered)
            animator.SetTrigger("attack");
    }
}

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

    private Vector2 moveDirection = Vector2.zero;

    [SerializeField]
    private SpriteRenderer spriteRender;

    [SerializeField]
    private Animator animator;

    private void Awake()
    {
        playerControls = new InputSystemActions();
    }

    private void OnEnable()
    {
        playerControls.Enable();

        move = playerControls.Player.Move;
        move.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();

        move.Disable();
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
    }
}

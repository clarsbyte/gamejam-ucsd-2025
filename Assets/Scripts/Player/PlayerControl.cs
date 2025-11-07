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

    private InputAction roll;

    private InputAction attack;

    // Everything related to player visuals
    [SerializeField]
    private SpriteRenderer spriteRender;

    [SerializeField]
    private Animator animator;

    // Reference to weapon
    [SerializeField]
    private WeaponHit weapon;

    private double attackCooldown = 1;
    private double currentAttackCooldown;
    private double rollCooldown = 1;
    private double currentRollCooldown;

    // Runs before initialization
    private void Awake()
    {
        playerControls = new InputSystemActions();

        // Check if weapon reference is set
        if (weapon == null)
        {
            Debug.LogWarning(
                "PlayerControl: Weapon reference is NULL! Trying to find weapon in children..."
            );
            weapon = GetComponentInChildren<WeaponHit>();
            if (weapon != null)
            {
                Debug.Log("Found weapon automatically: " + weapon.gameObject.name);
            }
            else
            {
                Debug.LogError(
                    "PlayerControl: Could not find WeaponHit component in children! Please attach WeaponHit script to a child GameObject or assign it manually."
                );
            }
        }
        else
        {
            Debug.Log("PlayerControl: Weapon reference is set to: " + weapon.gameObject.name);
        }
    }

    // Enables/tracks the inputs
    private void OnEnable()
    {
        playerControls.Enable();

        move = playerControls.Player.Move;
        move.Enable();

        attack = playerControls.Player.Attack;
        attack.Enable();

        roll = playerControls.Player.Roll;
        roll.Enable();
    }

    // Disables the inputs
    private void OnDisable()
    {
        playerControls.Disable();

        move.Disable();
        attack.Disable();
        roll.Disable();
    }

    private void playerRollStart()
    {
        moveSpeed = 4f;
    }

    private void playerRollEnd()
    {   
        moveSpeed = 1f;
    }

    private void updateAnimationStates()
    {
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

    private void playerMove()
    {
        // animator.SetBool("legSacrificed", true);

        moveDirection = move.ReadValue<Vector2>();

        rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        if (rb.linearVelocity != Vector2.zero)
        {
            updateAnimationStates();

            animator.SetBool("walking", true);
        }
        else
        {
            animator.SetBool("walking", false);
            animator.SetBool("horizontal", false);
            animator.SetBool("up", false);
            animator.SetBool("down", false);
        }
    }

    private void playerRoll()
    {
        playerRollStart();
        animator.SetTrigger("roll");
    }

    private void playerAttack()
    {
        if (animator.GetBool("up"))
            animator.SetTrigger("attackUp");
        else if (animator.GetBool("down"))
            animator.SetTrigger("attackDown");
        else if (animator.GetBool("horizontal") || !animator.GetBool("walking"))
            animator.SetTrigger("attackHorizontal");
    }

    // Called by animation event when attack starts
    private void eventAnimationFunctionStart()
    {
        Debug.Log("Attack animation started");
        if (weapon != null)
        {
            weapon.EnableWeapon();
        }
        else
        {
            Debug.LogWarning("Weapon reference not set in PlayerControl!");
        }
    }

    // Called by animation event when attack ends
    private void eventAnimationFunctionEnd()
    {
        Debug.Log("Attack animation ended");
        if (weapon != null)
        {
            weapon.DisableWeapon();
        }
    }

    // Update is called once per frame
    void Update()
    {
        playerMove();
        // playerRoll();

        currentAttackCooldown += Time.deltaTime;
        currentRollCooldown += Time.deltaTime;

        if (attack.triggered && currentAttackCooldown >= attackCooldown)
        {
            currentAttackCooldown = 0;
            playerAttack();
        }

        if (roll.triggered && currentRollCooldown >= rollCooldown)
        {
            currentRollCooldown = 0;
            playerRoll();
        }

        if (currentRollCooldown >= rollCooldown)
        {
            playerRollEnd();
        }

    }
}

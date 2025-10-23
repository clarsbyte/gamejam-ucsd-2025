using UnityEngine;

public class WeaponHit : MonoBehaviour
{
    private int count = 0;

    [SerializeField]
    [Tooltip(
        "Assign a specific collider for the weapon. If null, won't disable any collider (for separate weapon GameObjects)."
    )]
    private Collider2D weaponCollider;

    void Start()
    {
        Debug.Log("WeaponHit script started on: " + gameObject.name);

        // Only manage collider if one is specifically assigned
        if (weaponCollider != null)
        {
            Debug.Log("Weapon has assigned collider. IsTrigger: " + weaponCollider.isTrigger);
            // Disable collider by default (only enable during attack)
            weaponCollider.enabled = false;
            Debug.Log("Weapon collider disabled by default");
        }
        else
        {
            Debug.LogWarning(
                "WeaponHit: No weapon collider assigned. Weapon will always be active (not recommended if on Player). Create a separate weapon GameObject or assign a specific collider."
            );
        }
    }

    // Called by animation event to enable weapon hitbox
    public void EnableWeapon()
    {
        if (weaponCollider != null)
        {
            weaponCollider.enabled = true;
            Debug.Log("Weapon enabled!");
        }
    }

    // Called by animation event to disable weapon hitbox
    public void DisableWeapon()
    {
        if (weaponCollider != null)
        {
            weaponCollider.enabled = false;
            Debug.Log("Weapon disabled!");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(
            "WeaponHit triggered by: "
                + other.gameObject.name
                + " with tag: "
                + other.gameObject.tag
        );

        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy hit! Count: " + ++count);
            EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(10);
                Debug.Log("Dealt 10 damage to enemy");
            }
            else
            {
                Debug.LogWarning("Enemy object missing EnemyHealth component!");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Running");
    }
}

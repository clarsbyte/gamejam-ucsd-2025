using UnityEngine;

public class WeaponHit : MonoBehaviour
{
    public int enemiesKilled = 0;

    [SerializeField]
    [Tooltip(
        "Assign a specific collider for the weapon. If null, won't disable any collider (for separate weapon GameObjects)."
    )]
    private Collider2D weaponCollider;

    private int hits = 0;

    void Start()
    {
        // Debug.Log("WeaponHit script started on: " + gameObject.name);

        // // Only manage collider if one is specifically assigned
        // if (weaponCollider != null)
        // {
        //     Debug.Log("Weapon has assigned collider. IsTrigger: " + weaponCollider.isTrigger);
        //     // Disable collider by default (only enable during attack)
        //     weaponCollider.enabled = false;
        //     Debug.Log("Weapon collider disabled by default");
        // }
        // else
        // {
        //     Debug.LogWarning(
        //         "WeaponHit: No weapon collider assigned. Weapon will always be active (not recommended if on Player). Create a separate weapon GameObject or assign a specific collider."
        //     );
        // }
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
            Debug.Log("LOOK AT ME Weapon disabled!");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                if (enemyHealth.currentHealth <= 10)
                    ++enemiesKilled;

                if (!enemyHealth.iFrames)
                {
                    weaponCollider.enabled = false;
                    // DisableWeapon();

                    // Debug.Log("AFTER DISABLING THE WEAPON");

                    // Debug.Log("Enemy not in iFrames");
                    Debug.Log("Dealt " + (++hits) + " hits");
                    Debug.Log("Weapon collider status: " + weaponCollider.isActiveAndEnabled);

                    enemyHealth.TakeDamage(10);
                    enemyHealth.iFrames = true;

                    Debug.Log("Enemy health is: " + enemyHealth.currentHealth);
                }
                // else
                // {
                //     Debug.Log("iFrames for " + (1 - enemyHealth.timeIniFrames));
                // }
            }
            else
            {
                Debug.LogWarning("Enemy object missing EnemyHealth component!");
            }
        }
    }
}

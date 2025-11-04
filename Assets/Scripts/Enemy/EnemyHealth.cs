using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 50;
    public int currentHealth;

    public bool iFrames = false;
    public double timeIniFrames = 0;

    private int hitsTaken = 0;

    [SerializeField]
    private Rigidbody2D rb;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (!iFrames)
            currentHealth -= damage;

        Debug.Log("Took " + (++hitsTaken) + " hits + " + iFrames);
        // Debug.Log($"Enemy took {damage} damage. Health: {currentHealth}/{maxHealth}");

        if (currentHealth <= 0)
            Die();
    }

    private void Die()
    {
        // Debug.Log("Enemy died!");
        Destroy(gameObject);
    }

    void Update()
    {
        if (iFrames)
            timeIniFrames += Time.deltaTime;

        if (timeIniFrames >= 1)
        {
            iFrames = false;
            timeIniFrames = 0;
            rb.simulated = true;
            Debug.Log("iFrames now disabled");
        }
    }
}

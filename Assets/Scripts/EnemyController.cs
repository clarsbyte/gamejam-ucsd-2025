using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private float moveSpeed = 1f;

    [SerializeField]
    private GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() { }

    private void chasePlayer()
    {
        Vector3 direction = player.transform.position - transform.position;
        Vector3 normalizedDirection = direction.normalized;

        rb.linearVelocity = new Vector2(
            normalizedDirection.x * moveSpeed,
            normalizedDirection.y * moveSpeed
        );
    }

    // Update is called once per frame
    void Update()
    {
        chasePlayer();
    }
}

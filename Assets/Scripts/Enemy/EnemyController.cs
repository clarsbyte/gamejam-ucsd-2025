using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    // [SerializeField]
    private float moveSpeed = 0.5f;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private SpriteRenderer spriteRender;

    // private static int id = 0;
    // public int cloneId;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() { }

    void Awake() { }

    private void chasePlayer()
    {
        Vector3 direction = player.transform.position - transform.position;
        Vector3 normalizedDirection = direction.normalized;

        rb.linearVelocity = new Vector2(
            normalizedDirection.x * moveSpeed,
            normalizedDirection.y * moveSpeed
        );

        // Debug.Log(normalizedDirection);

        if (rb.linearVelocityX != 0)
            spriteRender.flipX = rb.linearVelocityX < 0;
    }

    // Update is called once per frame
    void Update()
    {
        // chasePlayer();
    }
}

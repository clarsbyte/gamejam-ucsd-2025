using System.Runtime.CompilerServices;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField]
    protected GameObject self;

    [SerializeField]
    protected Rigidbody2D rb;

    [SerializeField]
    protected float moveSpeed = 0.5f;

    [SerializeField]
    protected GameObject player;

    // Awake is called before the first frame
    void Awake() { }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() { }

    protected void chasePlayer()
    {
        Vector3 direction = player.transform.position - transform.position;
        Vector3 normalizedDirection = direction.normalized;

        rb.linearVelocity = new Vector2(
            normalizedDirection.x * moveSpeed,
            normalizedDirection.y * moveSpeed
        );
    }
}

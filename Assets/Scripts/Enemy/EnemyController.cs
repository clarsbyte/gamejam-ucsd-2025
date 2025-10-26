using UnityEngine;

public class EnemyController : BaseEnemy
{
    [SerializeField]
    private SpriteRenderer spriteRender;

    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     Debug.Log("Triggered by " + collision.gameObject.tag);
    // }

    // Update is called once per frame
    void Update()
    {
        chasePlayer();

        if (rb.linearVelocityX != 0)
            spriteRender.flipX = rb.linearVelocityX < 0;
    }
}

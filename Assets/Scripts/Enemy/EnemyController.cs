using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyController : BaseEnemy
{
    [SerializeField]
    private SpriteRenderer spriteRender;

    // Update is called once per frame
    void Update()
    {
        chasePlayer();

        if (rb.linearVelocityX != 0)
            spriteRender.flipX = rb.linearVelocityX < 0;
    }
}

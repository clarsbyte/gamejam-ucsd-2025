using UnityEngine;

public class FireBallControl : BaseEnemy
{
    private float timeRendered = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            Destroy(self);
        // self.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timeRendered += Time.deltaTime;

        // Fireball survives for 10 seconds
        if (timeRendered >= 10)
            Destroy(self);

        // Vector from the fireball to the player
        Vector3 vectorToPlayer = player.transform.position - this.transform.position;

        // Calculate the angle to face the player
        float angleToRotate = Mathf.Atan2(vectorToPlayer.y, vectorToPlayer.x) * Mathf.Rad2Deg;

        this.transform.rotation = Quaternion.Euler(0, 0, angleToRotate);

        chasePlayer();
    }
}

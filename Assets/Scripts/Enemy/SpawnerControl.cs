using System.Collections;
using UnityEngine;

public class SpawnerControl : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;

    public void spawnEnemy()
    {
        GameObject newEnemy = Instantiate(
            enemy,
            new Vector3(transform.position.x, transform.position.y, 0),
            Quaternion.identity
        );

        newEnemy.SetActive(true);
    }

    public void spawnWave(int amount)
    {
        for (int i = 0; i < amount; ++i)
            Invoke(nameof(spawnEnemy), Random.Range(1f, 3.5f));
    }
}

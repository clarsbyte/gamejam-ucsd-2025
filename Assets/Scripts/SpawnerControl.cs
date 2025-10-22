using System.Collections;
using UnityEngine;

public class SpawnerControl : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;

    // [SerializeField]
    // private float interval = 3.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(spawnEnemy(enemy, 10, 0));
    }

    private IEnumerator spawnEnemy(GameObject enemy, int count, int current)
    {
        yield return new WaitForSeconds(Random.Range(1f, 3.5f));
        GameObject newEnemy = Instantiate(
            enemy,
            new Vector3(transform.position.x, transform.position.y, 0),
            Quaternion.identity
        );
        newEnemy.SetActive(true);

        if (count != current)
            StartCoroutine(spawnEnemy(enemy, count, ++current));

        string msg = string.Format("Spawned {0} out of {1} enemies", current, count);

        Debug.Log(msg);
    }

    // Update is called once per frame
    // void Update() { }
}

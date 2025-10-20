using UnityEngine;

public class WeaponHit : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() { }

    private int count = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Dummy")
        {
            Debug.Log("Dummy hit trigger" + ++count);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Running");
    }
}

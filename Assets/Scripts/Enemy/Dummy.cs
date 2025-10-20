using UnityEngine;

public class Dummy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() { }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
            Debug.Log("I (the dummy) was hit by the weapon");
    }

    // Update is called once per frame
    void Update() { }
}

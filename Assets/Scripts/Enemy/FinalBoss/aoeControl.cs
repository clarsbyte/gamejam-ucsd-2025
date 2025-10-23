using UnityEngine;

public class aoeControl : MonoBehaviour
{
    [SerializeField]
    private GameObject self; // Adjust this value for faster/slower growth

    [SerializeField]
    private float growthRate = 0.75f; // Adjust this value for faster/slower growth

    void Update()
    {
        // Increase the local scale over time
        if (self.activeSelf)
            transform.localScale +=
                new Vector3(growthRate, growthRate, growthRate) * Time.deltaTime;

        if (transform.localScale.x >= 5)
            Destroy(self);
    }
}

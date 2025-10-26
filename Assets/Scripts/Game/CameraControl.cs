using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(
            player.transform.position.x,
            player.transform.position.y,
            -10
        );
    }
}

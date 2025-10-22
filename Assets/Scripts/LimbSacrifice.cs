using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LimbSacrifice : MonoBehaviour
{
    public GameObject rarm;
    public GameObject larm;
    public GameObject rleg;
    public GameObject lleg;

    public PlayerControl player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rarm.GetComponent<Image>().color = Color.white;
        larm.GetComponent<Image>().color = Color.white;
        rleg.GetComponent<Image>().color = Color.white;
        lleg.GetComponent<Image>().color = Color.white;
    }

    public void OnLimbClicked(LimbType limb)
    {
        switch (limb)
        {
            case LimbType.RightArm:
                Debug.Log("Right arm clicked!");
                rarm.GetComponent<Image>().color = Color.red;
                break;
                
            case LimbType.LeftArm:
                Debug.Log("Left arm clicked!");
                larm.GetComponent<Image>().color = Color.red;
                break;
                
            case LimbType.RightLeg:
                Debug.Log("Right leg clicked!");
                rleg.GetComponent<Image>().color = Color.red;
                player.moveSpeed = 0.5f;
                break;
                
            case LimbType.LeftLeg:
                Debug.Log("Left leg clicked!");
                lleg.GetComponent<Image>().color = Color.red;
                player.moveSpeed = 0.5f;
                break;
        }
    }
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class EyeSacrifice : MonoBehaviour, IPointerClickHandler
{
    public int quantity = 10;
    public PlayerControl player;
    public TextMeshProUGUI quantitytxt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("eye clicked!");
        
        if(quantity>0 && player.currentHealth<player.maxHealth){
            player.healthBar.setHealth(++player.currentHealth);
            quantitytxt.text = (--quantity).ToString();
            Debug.Log(quantitytxt.text);
        }
    }
}

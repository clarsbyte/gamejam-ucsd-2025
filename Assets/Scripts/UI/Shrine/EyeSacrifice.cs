using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EyeSacrifice : MonoBehaviour, IPointerClickHandler
{
    public int quantity = 10;
    public PlayerStatus player;
    public TextMeshProUGUI quantitytxt;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("eye clicked!");

        if (quantity > 0 && player.currentHealth < player.maxHealth)
        {
            player.healthBar.setHealth(++player.currentHealth);
            quantitytxt.text = (--quantity).ToString();
            Debug.Log(quantitytxt.text);
        }
    }
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum LimbType { RightArm, LeftArm, RightLeg, LeftLeg }

public class Limb : MonoBehaviour, IPointerClickHandler
{
    public LimbType limbType;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        LimbSacrifice manager = FindObjectOfType<LimbSacrifice>();
        if (manager != null)
        {
            manager.OnLimbClicked(limbType);
        }
    }
}

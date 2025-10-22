 using UnityEngine;

public class Shrine : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameObject ShrineView;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ShrineView.SetActive(false);
    }

    private void OpenShrine(){
        Debug.Log("sacrifice accepted");
        ShrineView.SetActive(!ShrineView.activeSelf);
    }

    public bool CanInteract()
    {
        throw new System.NotImplementedException();
    }

    public void Interact()
    {
        OpenShrine();
    }

}

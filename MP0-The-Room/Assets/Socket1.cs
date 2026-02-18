using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class Socket1 : MonoBehaviour
{
    public XRSocketInteractor socket;
    public GameObject Light1;
    public void OnObjectPlaced()
    {
        UnityEngine.XR.Interaction.Toolkit.Interactables.IXRSelectInteractable interactable = socket.GetOldestInteractableSelected();
        if (interactable != null && interactable.transform.name == "Clue1")
        {
            CluesAndOpenDoor.clue1Collected = true;
        }
    }
    public void OnObjectRemoved()
    {
        CluesAndOpenDoor.clue1Collected = false;
    }
    public void Start()
    {
        socket.selectEntered.AddListener(_ => OnObjectPlaced());
        socket.selectExited.AddListener(_ => OnObjectRemoved());
    }
}
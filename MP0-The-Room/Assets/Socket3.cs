using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
public class Socket3 : MonoBehaviour
{
    public XRSocketInteractor socket;
    public void OnObjectPlaced()
    {
        UnityEngine.XR.Interaction.Toolkit.Interactables.IXRSelectInteractable interactable = socket.GetOldestInteractableSelected();
        if (interactable != null && interactable.transform.name == "Clue3")
        {
            CluesAndOpenDoor.clue2Collected = true;
        }
    }
    public void OnObjectRemoved()
    {
        CluesAndOpenDoor.clue2Collected = false;
    }
    public void Start()
    {
        socket.selectEntered.AddListener(_ => OnObjectPlaced());
        socket.selectExited.AddListener(_ => OnObjectRemoved());
    }
}

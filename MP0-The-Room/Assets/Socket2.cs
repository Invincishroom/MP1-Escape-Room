using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
public class Socket2 : MonoBehaviour
{
    public XRSocketInteractor socket;
    public void OnObjectPlaced()
    {
        UnityEngine.XR.Interaction.Toolkit.Interactables.IXRSelectInteractable interactable = socket.GetOldestInteractableSelected();
        if (interactable != null && interactable.transform.name == "Clue2")
        {
            CluesAndOpenDoor.clue3Collected = true;
        }
    }
    public void OnObjectRemoved()
    {
        CluesAndOpenDoor.clue3Collected = false;
    }
    public void Start()
    {
        socket.selectEntered.AddListener(_ => OnObjectPlaced());
        socket.selectExited.AddListener(_ => OnObjectRemoved());
    }
}

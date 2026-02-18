using UnityEngine;

public class EnergyCube : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform energyCubeObject;
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;
    
    void Start()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(x => OnGrabbed());
    }

    void OnGrabbed()
    {
        Energy.energyAmount += 10;
        energyCubeObject.gameObject.SetActive(false);
    }
}

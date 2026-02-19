using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
namespace NavKeypad { 
public class KeypadInteractionFPV : MonoBehaviour
{
    public InputActionReference interactAction;
    public Transform PlayerPosition;
    private GameObject currentButton;
    private Material buttonMaterial;
    public Material HighlightMaterial;
    private void Awake(){
        interactAction.action.Enable();
        interactAction.action.performed += ctx => Interact();
    }
    private void Interact()
    {
        Ray ray = new Ray(PlayerPosition.position, PlayerPosition.forward);
        float maxDistance = 3f; // Adjust as needed
        if (Physics.Raycast(ray, out var hit, maxDistance))
        {
            if (hit.collider.TryGetComponent(out KeypadButton keypadButton))
            {
                keypadButton.PressButton();
            }
        }
    }
    private void Update()
    {
        Ray ray = new Ray(PlayerPosition.position, PlayerPosition.forward);
        float maxDistance = 3f; // Adjust as needed
        if (Physics.Raycast(ray, out var hit, maxDistance))
        {
            //Debug.DrawLine(ray.origin, hit.point, Color.red);
            //Debug.Log($"Hit: {hit.collider.gameObject.name}");
            if (hit.collider.TryGetComponent(out KeypadButton _))
            {
                if (currentButton != hit.collider.gameObject)
                {

                    if (currentButton != null)
                    {
                        currentButton.GetComponent<Renderer>().material = buttonMaterial;
                    }
                    currentButton = hit.collider.gameObject;
                    buttonMaterial = currentButton.GetComponent<Renderer>().material;
                    currentButton.GetComponent<Renderer>().material = HighlightMaterial;
                }
            }
            else
            {
                if (currentButton != null)
                {
                    currentButton.GetComponent<Renderer>().material = buttonMaterial;
                    currentButton = null;
                }
            }
        }
    }
}
}
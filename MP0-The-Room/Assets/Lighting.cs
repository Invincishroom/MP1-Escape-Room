using UnityEngine;
using UnityEngine.InputSystem;


public class Lighting : MonoBehaviour
{
    public InputActionReference toggleLightAction;
    public Light light;
    public bool isOn = true;
    void Start()
    {
        light = GetComponent<Light>();
        toggleLightAction.action.Enable();
        toggleLightAction.action.performed += ctx => ToggleLight();
    }
    void ToggleLight()
    {
        isOn = !isOn;
        if (isOn)
        {
            light.color = Color.white;
            light.intensity = 100f;
        }
        else
        {
            light.color = Color.red;
            light.intensity = 40f;
        }
    }
}


using UnityEngine;
using UnityEngine.InputSystem;
public class BreakOUt : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform originalPosition;
    public Transform targetPosition;
    public bool isAtOriginal = true;
    public InputActionReference moveAction;
    public CharacterController characterController;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        moveAction.action.Enable();
        moveAction.action.performed += ctx => MoveObject();
    }
    void MoveObject()
    {
        if (isAtOriginal)
        {
            characterController.enabled = false;
            originalPosition.position = transform.position;
            transform.position = targetPosition.position;
            characterController.enabled = true;
            isAtOriginal = false;
        }
        else
        {
            characterController.enabled = false;
            transform.position = originalPosition.position;
            characterController.enabled = true;
            isAtOriginal = true;
        }
    }
    
}
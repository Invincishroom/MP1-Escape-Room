using UnityEngine;
using UnityEngine.InputSystem;
public class GameStart : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform ScreenCanvasTransform;
    public CharacterController characterController;
    public Transform targetPosition;
    public void GameStartFunction()
    {
        ScreenCanvasTransform = GameObject.Find("ScreenCanvas").transform;
        targetPosition = GameObject.Find("TargetWarpPosition").transform;
        foreach (Transform child in ScreenCanvasTransform)
        {
            child.gameObject.SetActive(true);
        }
        characterController.enabled = false;
        characterController.transform.position = targetPosition.position;
        characterController.enabled = true;
        CluesAndOpenDoor.GameOver = 0; // Start the game
    }

}

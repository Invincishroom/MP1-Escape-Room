using UnityEngine;
using UnityEngine.InputSystem;

public class QuitButton: MonoBehaviour
{
    public InputActionReference quitAction;
    void Start()
    {
        quitAction.action.Enable();
        quitAction.action.performed += ctx => QuitGame();
    }
    void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}

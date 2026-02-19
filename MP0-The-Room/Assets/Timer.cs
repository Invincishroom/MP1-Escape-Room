using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
public class Timer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static float timeRemaining = 10f;
    public GameObject TimerTextObject;
    public Transform LossWarpPosition;
    public CharacterController characterController;
    // Update is called once per frame
    void Update()
    {
        if (CluesAndOpenDoor.GameOver != 0)
        {
            return;
        }   
        timeRemaining -= Time.deltaTime;
        float minute = Mathf.FloorToInt(timeRemaining / 60);
        float second = Mathf.FloorToInt(timeRemaining % 60);
        TimerTextObject.GetComponent<TextMeshProUGUI>().text = minute.ToString("00") + ":" + second.ToString("00");
        // Todo: add game over condition when time runs out
        if (timeRemaining <= 0)
        {
            CluesAndOpenDoor.GameOver = 2; // Game over due to time running out
            foreach (Transform child in GameObject.Find("ScreenCanvas").transform)
            {
                child.gameObject.SetActive(false);
            }
            characterController.enabled = false;
            characterController.transform.position = LossWarpPosition.position;
            characterController.enabled = true;
        }
    }
}

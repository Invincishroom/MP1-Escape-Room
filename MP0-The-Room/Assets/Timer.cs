using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float timeRemaining = 900f;
    public GameObject TimerTextObject;

    // Update is called once per frame
    void Update()
    {
        if (CluesAndOpenDoor.GameOver == 1)
        {
            return;
        }   
        timeRemaining -= Time.deltaTime;
        float minute = Mathf.FloorToInt(timeRemaining / 60);
        float second = Mathf.FloorToInt(timeRemaining % 60);
        TimerTextObject.GetComponent<TextMeshProUGUI>().text = minute.ToString("00") + ":" + second.ToString("00");
        // Todo: add game over condition when time runs out
    }
}

using UnityEngine;
using TMPro;
public class CluesAndOpenDoor : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static bool clue1Collected = false;
    public static bool clue2Collected = false;
    public static bool clue3Collected = false;
    public static int GameOver = -1; // -1 for not started, 0 for in progress, 1 for win, 2 for lose
    private Animator doorAnimator;
    public int CluesCollected = 0;
    public GameObject door;
    public Light Light1, Light2, Light3;
    public GameObject CluesText;
    private Color color1 = Color.green;
    private Color color2 = new Color(90f/255f, 142f/255f, 227f/255f, 1f);
    private Transform ScreenCanvasTransform;
    public TextMeshPro WinLossLabel, ScoreLabel;
    public void Start()
    {
        ScreenCanvasTransform = GameObject.Find("ScreenCanvas").transform;
        
    }
    public void Update()
    {
        if (GameOver != 0)
        {
            if (GameOver == 2)
        {
            WinLossLabel.text = "You Lose!";
            int gameScore = (int) Timer.timeRemaining + CluesCollected * 100 + Energy.energyAmount * 50;
            ScoreLabel.text = gameScore.ToString();
        }
            else if (GameOver == 1)
        {
            WinLossLabel.text = "You Win!";
            int gameScore = (int) Timer.timeRemaining + CluesCollected * 100 + Energy.energyAmount * 50;
            ScoreLabel.text = gameScore.ToString();
        }
            return;
        }
        Light1.color = clue1Collected ? color1 : color2;   
        Light2.color = clue2Collected ? color1 : color2;   
        Light3.color = clue3Collected ? color1 : color2;   
        CluesCollected = (clue1Collected ? 1 : 0) + (clue2Collected ? 1 : 0) + (clue3Collected ? 1 : 0); 
        CluesText.GetComponent<TextMeshProUGUI>().text = $"{CluesCollected}/3";
        if (CluesCollected == 3)
        {
            doorAnimator = door.GetComponent<Animator>();
            doorAnimator.Play("door_2_open", 0, 0.0f);
            GameOver = 1;
            foreach (Transform child in ScreenCanvasTransform)
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}

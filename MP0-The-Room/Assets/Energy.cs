using UnityEngine;
using TMPro;
public class Energy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static int energyAmount = 0;
    public GameObject EnergyCubeTextObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnergyCubeTextObject.GetComponent<TextMeshProUGUI>().text = energyAmount.ToString();
    }
}

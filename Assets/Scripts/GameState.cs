using UnityEngine;
using TMPro;

public class GameState : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI debugText;
    public static const int nStep = 5;
    public static int currentStep = 0;
    public static int[] scores = new int[3] { 0, 0, 0 };


    void Start()
    {
        ResetValues();
    }

    void Update()
    {
        
    }

    void ResetValues()
    {
        currentStep = 0;
        scores = new int[3] { 0, 0, 0 };
        UpdateDebugDisplay();
    }

    void UpdateDebugDisplay()
    {
        debugText.text = "";
        debugText.text += $"currentStep : {currentStep}\n"
            + $"scores[0] : {scores[0]}\n"
            + $"scores[1] : {scores[1]}\n"
            + $"scores[2] : {scores[2]}\n"
            ;
    }
}

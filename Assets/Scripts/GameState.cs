using UnityEngine;
using TMPro;

public class GameState : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI debugText;
    public static int currentStep = 0;

    public static int scoreNature = 0;
    public static int scoreTech = 0;
    public static int scoreSocial = 0;

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

        scoreNature = 0;
        scoreTech = 2;
        scoreSocial = 5;

        UpdateDebugDisplay();
    }

    void UpdateDebugDisplay()
    {
        debugText.text = "";
        debugText.text += $"currentStep : {currentStep}\n"
            + $"scoreNature : {scoreNature}\n"
            + $"scoreTech : {scoreTech}\n"
            + $"scoreSocial : {scoreSocial}\n"
            ;
    }
}

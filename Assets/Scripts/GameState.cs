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
        ApplyChoices();
    }

    void Update()
    {
        
    }

    void ApplyChoices()
    {
        scoreNature += Random.Range(-1, 2);
        scoreTech += Random.Range(-1, 2);
        scoreSocial += Random.Range(-1, 2);
        UpdateDebugDisplay();
    }

    void ResetValues()
    {
        currentStep = 0;

        scoreNature = 0;
        scoreTech = 0;
        scoreSocial = 0;

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

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
        scoreNature += Random.Range(-1, 10);
        scoreTech += Random.Range(-1, 10);
        scoreSocial += Random.Range(-1, 10);
        UpdateDebugDisplay();
    }

    int Score2Level(int score) {
        if (score <= 2) return 0;
        if (score <= 4) return 1;
        if (score <= 5) return 2;
        return 3;        
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
            + $"Nature : {scoreNature} - {Score2Level(scoreNature)}\n"
            + $"Tech : {scoreTech} - {Score2Level(scoreTech)}\n"
            + $"Social : {scoreSocial} - {Score2Level(scoreSocial)}\n"
            ;
    }
}

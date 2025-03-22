using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameState : MonoBehaviour
{
    public const int nMessages = 8;
    [Header("Configuration de textes")]
    [Tooltip("Nature - messages pour tous les scores")]
    public List<string> natureMessages = new List<string>();
    [Tooltip("Tech - messages pour tous les scores")]
    public List<string> techMessages = new List<string>();
    [Tooltip("Social - messages pour tous les scores")]
    public List<string> socialMessages = new List<string>();
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

    int GetNatureLevel()
    {
        return Score2Level(scoreNature);
    }

    int GetTechLevel()
    {
        return Score2Level(scoreTech);
    }

    int GetSocialLevel()
    {
        return Score2Level(scoreSocial);
    }

    int ClampScore(int score)
    {
        return Mathf.Clamp(score, 0, nMessages - 1);
    }

    string GetNatureMessage()
    {
        return natureMessages[ClampScore(scoreNature)];
    }

    string GetTechMessage()
    {
        return techMessages[ClampScore(scoreTech)];
    }

    string GetSocialMessage()
    {
        return natureMessages[ClampScore(scoreSocial)];
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
            + $"Nature : {scoreNature} - {GetNatureLevel()} - {GetNatureMessage()}\n"
            + $"Tech : {scoreTech} - {GetTechLevel()} - {GetTechMessage()}\n"
            + $"Social : {scoreSocial} - {GetSocialLevel()} - {GetSocialMessage()}\n"
            ;
    }
}

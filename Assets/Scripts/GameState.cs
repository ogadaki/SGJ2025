using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameState : MonoBehaviour
{
    [Serializable]
    public class TextEntry
    {        
        [TextArea(3, 10)]
        public string content;
    }
    public const int nMessages = 8;
    [Header("Configuration de textes")]
    [Tooltip("Nature - messages pour tous les scores")]
    public TextEntry[] natureMessages;
    [Tooltip("Tech - messages pour tous les scores")]
    public TextEntry[] techMessages;
    [Tooltip("Social - messages pour tous les scores")]
    public TextEntry[] socialMessages;
    [SerializeField] private TextMeshProUGUI debugText;
    public static int currentStep = 0;

    public static int scoreNature = 0;
    public static int scoreTech = 0;
    public static int scoreSocial = 0;
    public static bool debug = true;

    void Start()
    {
        ResetValues();
        if (debug) {
            UpdateScores();
            NextStep();
            NextStep();
        }
    }

    void Update()
    {
        
    }

    void NextStep()
    {
        currentStep++;
        UpdateDebugDisplay();
    }

    void UpdateScores(int incrNature, int incrTech, int incrSocial)
    {
        scoreNature += incrNature;
        scoreTech += incrTech;
        scoreSocial += incrSocial;
        UpdateDebugDisplay();
    }

    void UpdateScores()
    {
        UpdateScores(
            UnityEngine.Random.Range(-1, 10),
            UnityEngine.Random.Range(-1, 10),
            UnityEngine.Random.Range(-1, 10)
        );
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

    string MessageFromScore(TextEntry[] messages, int score)
    {
        string message = messages[ClampScore(score)].content;
        return string.IsNullOrEmpty(message) ? $"message pour le score {score}" : message;
    }

    string GetNatureMessage()
    {
        return MessageFromScore(natureMessages, scoreNature);
    }

    string GetTechMessage()
    {
        return MessageFromScore(techMessages, scoreTech);
    }

    string GetSocialMessage()
    {
        return MessageFromScore(socialMessages, scoreSocial);
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
        if (debug) {
            debugText.text = "Info de debug\n\n<size=60%>";
            debugText.text += $"currentStep : {currentStep}\n"
                + $"\n"
                + $"Nature : {scoreNature} - {GetNatureLevel()}\n"
                + $"{GetNatureMessage()}\n\n"
                + $"Tech : {scoreTech} - {GetTechLevel()}"
                + $"\n{GetTechMessage()}\n\n"
                + $"Social : {scoreSocial} - {GetSocialLevel()}"
                + $"\n{GetSocialMessage()}\n\n"
                ;
        }
    }
}

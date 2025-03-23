using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameState : MonoBehaviour
{
    public string gameOverSocial;
    public string gameOverTechno;
    public string gameOverNature;
    public string gameOverBravo;

    public GameObject panelGameOverRate;
    public TextMeshProUGUI raisonGameOver;
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
    public int currentStep = 1;

    public GameObject panelFin;

    
    public gestionnaireMarqueur[] gestionnaireObjetsTemoins;

    public FonduEnNoir panelFondu;

    public dictionnaireQuestions dicoQuestions;

    public GameObject panelQuestions;
    public GameObject panelConsigne;
    public GameObject panelLogs;

    public  int scoreNature = 0;
    public  int scoreTech = 0;
    public  int scoreSocial = 0;
    public  bool debug = true;

    public bool nouvelleEtape;

    void Start()
    {
        ResetValues();
    }

    void Update()
    {
        /*if(nouvelleEtape){
            nouvelleEtape = false;
            foreach(gestionnaireMarqueur objetTemoin in gestionnaireObjetsTemoins){
                objetTemoin.checkChangementEtat(this.GetNatureLevel());
            }
        }*/
    }

    void NextStep()
    {
        currentStep++;
        UpdateDebugDisplay();
    }

    public void avancerEtape(){
        currentStep++;
        this.panelFondu.FadeToBlackThenFromBlack();
        // -------- En fait ces appels doivent etre fait dans le fade pour pas qu'on voit le changement avant le noir
        // appel de fonction de remplacement des differents texte de questions et choix
        // appel de remplacement / concat du texte de log
        // appel de fonctiond d'avancement sur la "ligne du temps"
    }

    public void avancerEtapeRestart(){
        currentStep++;
        this.panelFondu.FadeToBlackThenFromBlackRestart();
    }

    public void lancerGameOver(){
        if(currentStep >= 6){
            //this.panelFondu.FadeToBlackThenFromBlack();
            this.activerGameOver();
            this.panelConsigne.SetActive(false);
            this.panelLogs.SetActive(false);
            this.panelQuestions.SetActive(false);
            this.panelFin.SetActive(true);
        }
    }
    public void UpdateScores(int incrNature, int incrTech, int incrSocial)
    {
        scoreNature += incrNature;
        scoreTech += incrTech;
        scoreSocial += incrSocial;
        UpdateDebugDisplay();
    }

    public void UpdateScores()
    {
        UpdateScores(
            UnityEngine.Random.Range(-1, 10),
            UnityEngine.Random.Range(-1, 10),
            UnityEngine.Random.Range(-1, 10)
        );
    }

    int Score2Level(int score) {
        if(score < 0){
            currentStep = 6;
            return 0;
        }
        if (score <= 2) return 0;
        if (score <= 4) return 1;
        if (score <= 5) return 2;
        return 3;        
    }

    public int GetNatureLevel()
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
        currentStep = 1;

        scoreNature = 3;
        scoreTech = 3;
        scoreSocial = 3;

        UpdateDebugDisplay();
    }

    public void resetGame(){
        currentStep = 0;
        scoreNature = 3;
        scoreTech = 3;
        scoreSocial = 3;
        UpdateDebugDisplay();
        this.panelFin.SetActive(false);
        avancerEtapeRestart();
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

    public int getCurrentStep(){
        return currentStep;
    }

    public void activerGameOver(){
        string gameOver = gameOverBravo;
        if(this.scoreNature<0 || this.scoreSocial<0 || this.scoreTech<0){
            gameOver = "";
            this.panelGameOverRate.SetActive(true);
        }
        else{
            this.panelGameOverRate.SetActive(false);
        }
        if(this.scoreNature<0){
            gameOver += gameOverNature;
        }
        if(this.scoreSocial<0){
            gameOver += gameOverSocial;
        }
        if(this.scoreTech < 0){
            gameOver += gameOverTechno;
        }
        this.raisonGameOver.text = gameOver;
    }
}

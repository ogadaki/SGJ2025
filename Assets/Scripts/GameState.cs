using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public string gameOverSocial;
    public string gameOverTechno;
    public string gameOverNature;
    public string gameOverBravo;

    public GameObject Fond_Step_1;
    public GameObject Fond_Step_2;
    public GameObject Fond_Step_3;
    public GameObject Fond_Step_4;
    public GameObject Fond_Step_5;
    public GameObject Fond_Step_6_FINAL;

    public GameObject Nature_Niveau_0;
    public GameObject Nature_Niveau_1;
    public GameObject Nature_Niveau_2;
    public GameObject Nature_Niveau_3;

    public GameObject Techno_Niveau_0;
    public GameObject Techno_Niveau_1;
    public GameObject Techno_Niveau_2;
    public GameObject Techno_Niveau_3;

    public GameObject Social_Niveau_0;
    public GameObject Social_Niveau_1;
    public GameObject Social_Niveau_2;
    public GameObject Social_Niveau_3;

    public GameObject panelGameOverRate;
    public GameObject panelGameOverSuccess;
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

    public TextMeshProUGUI texteLogs;
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
    public  bool debug = false;
    public bool scoresUnchangedNature = false;
    public bool scoresUnchangedTech = false;
    public bool scoresUnchangedSocial = false;

    public bool nouvelleEtape;

    public bool panelsVisible;

    public gestionnaireSons sonsSociaux;
    public gestionnaireSons sonsTechno;
    public gestionnaireSonsNature sonsNature;
    public GameObject panelSouris;

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
        // Appuyer sur 'R' pour redémarrer
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartScene();
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
        this.panelSouris.SetActive(true);
        RestartScene();
    }

    public void lancerGameOver(){
        /*if(currentStep >1){
            this.panelLogs.SetActive(true);
        }*/
        if(currentStep == 6){
            this.panelSouris.SetActive(false);
        }
        if(currentStep >= 6){
            //this.panelFondu.FadeToBlackThenFromBlack();
            this.panelConsigne.SetActive(false);
            this.panelLogs.SetActive(false);
            this.panelQuestions.SetActive(false);
            this.panelFin.SetActive(true);
            this.activerGameOver();
        }
    }
    public void UpdateScores(int incrNature, int incrTech, int incrSocial)
    {
        int previousScoreNature = scoreNature;
        int previousScoreTech = scoreTech;
        int previousScoreSocial = scoreSocial;

        scoreNature += incrNature;
        scoreTech += incrTech;
        scoreSocial += incrSocial;

        if (scoreNature == previousScoreNature)
        {
            scoresUnchangedNature = true;
        }
        else
        {
            scoresUnchangedNature = false;
        }
        if (scoreTech == previousScoreTech)
        {
            scoresUnchangedTech = true;
        }
        else
        {
            scoresUnchangedTech = false;
        }
        if (scoreSocial == previousScoreSocial)
        {
            scoresUnchangedSocial = true;
        }
        else
        {
            scoresUnchangedSocial = false;
        }
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
        if (scoresUnchangedNature)
        {
            return "L’équilibre sensible a juste été maintenu. Ni évolution ni altération notable.";
        }
        else
        {
            return MessageFromScore(natureMessages, scoreNature);
        }        
    }

    string GetTechMessage()
    {
        if (scoresUnchangedTech)
        {
            return "Aucune variation technologique, le système a été maintenu à niveau et reste tel qu’il était.";
        }
        else
        {
            return MessageFromScore(techMessages, scoreTech);
        }        
    }

    string GetSocialMessage()
    {
        if (scoresUnchangedSocial)
        {
            return "Les relations à bord se sont maintenues telles qu’elles étaient. Pas d’amélioration, mais au moins pas de tensions accumulées.";
        }
        else
        {
            return MessageFromScore(socialMessages, scoreSocial);
        }
        
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

    public void UpdateLogs(){


        this.texteLogs.text = 
            $"\n"
                + $"<color=#66BB6A>{GetNatureMessage()}</color>\n\n"
                + $"\n<color=#4FC3F7>{GetTechMessage()}</color>\n\n"
                + $"\n<color=#C75B5B>{GetSocialMessage()}</color>\n\n"
                ;
    }

    public void UpdateVaisseau()
    {
        Debug.Log("UpdateVaisseau");

        Fond_Step_1.SetActive(currentStep == 1);
        Fond_Step_2.SetActive(currentStep == 2);
        Fond_Step_3.SetActive(currentStep == 3);
        Fond_Step_4.SetActive(currentStep == 4);
        Fond_Step_5.SetActive(currentStep == 5);
        Fond_Step_6_FINAL.SetActive(currentStep == 6);

        Nature_Niveau_0.SetActive(GetNatureLevel() == 0);
        Nature_Niveau_1.SetActive(GetNatureLevel() == 1);
        Nature_Niveau_2.SetActive(GetNatureLevel() == 2);
        Nature_Niveau_3.SetActive(GetNatureLevel() == 3);

        Techno_Niveau_0.SetActive(GetTechLevel() == 0);
        Techno_Niveau_1.SetActive(GetTechLevel() == 1);
        Techno_Niveau_2.SetActive(GetTechLevel() == 2);
        Techno_Niveau_3.SetActive(GetTechLevel() == 3);

        Social_Niveau_0.SetActive(GetSocialLevel() == 0);
        Social_Niveau_1.SetActive(GetSocialLevel() == 1);
        Social_Niveau_2.SetActive(GetSocialLevel() == 2);
        Social_Niveau_3.SetActive(GetSocialLevel() == 3);
    }

    public int getCurrentStep(){
        return currentStep;
    }

    public void activerGameOver(){
        string gameOver = gameOverBravo;
        if(this.scoreNature<0 || this.scoreSocial<0 || this.scoreTech<0){
            gameOver = "";
            this.panelGameOverRate.SetActive(true);
            this.panelGameOverSuccess.SetActive(false);
        }
        else{
            this.panelGameOverSuccess.SetActive(true);
            this.panelGameOverRate.SetActive(false);
        }

        if(this.scoreNature<0){
            gameOver += $"{gameOverNature}\n\n";
        }
        if(this.scoreSocial<0){
            gameOver += $"{gameOverSocial}\n\n";
        }
        if(this.scoreTech < 0){
            gameOver += $"{gameOverTechno}\n\n";
        }
        this.raisonGameOver.text = gameOver;
    }

    public void activerSons(){
        this.sonsSociaux.activerSourceSon(this.Score2Level(this.scoreSocial));
        this.sonsNature.activerSourceSon(this.Score2Level(this.scoreNature));
        this.sonsTechno.activerSourceSon(this.Score2Level(this.scoreTech));
        /*this.sonsNature.activerSourceSon(this.Score2Level(this.scoreNature));
        this.sonsTechno.activerSourceSon(this.Score2Level(this.scoreTech));*/
    }
}

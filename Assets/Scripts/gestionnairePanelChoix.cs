using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class gestionnairePanelChoix : MonoBehaviour
{
    public GameState gameState;
    public Button validateButton;
    public GameObject panelChoix1;
    public GameObject panelChoix2;
    public GameObject panelChoix3;

    public TextMeshProUGUI demande1;
    public TextMeshProUGUI demande1Choix1;
    public choixDeMedia demande1Toggle1;
    public TextMeshProUGUI demande1Choix2;
    public choixDeMedia demande1Toggle2;
    public TextMeshProUGUI demande1Choix3;
    public choixDeMedia demande1Toggle3;
    public TextMeshProUGUI demande2;
    public TextMeshProUGUI demande2Choix1;
    public choixDeMedia demande2Toggle1;
    public TextMeshProUGUI demande2Choix2;
    public choixDeMedia demande2Toggle2;
    public TextMeshProUGUI demande2Choix3;
    public choixDeMedia demande2Toggle3;
    public TextMeshProUGUI demande3;
    public TextMeshProUGUI demande3Choix1;
    public choixDeMedia demande3Toggle1;
    public TextMeshProUGUI demande3Choix2;
    public choixDeMedia demande3Toggle2;
    public TextMeshProUGUI demande3Choix3;
    public choixDeMedia demande3Toggle3;

    public dictionnaireQuestions dicoQuestion;
    public int numeroEtape;

    void ChangeValidateButtonOnToggleChange(choixDeMedia choix)
    {
        Toggle toggle = choix.GetComponent<Toggle>();
        toggle.onValueChanged.AddListener((isOn) => CheckValidateButtonState());
    }

    bool toggleIsOn(choixDeMedia choix)
    {
        Toggle toggle = choix.GetComponent<Toggle>();
        return toggle.isOn;
    }

    void CheckValidateButtonState()
    {
        if (
            (
                toggleIsOn(demande1Toggle1)
                || toggleIsOn(demande1Toggle2)
                || toggleIsOn(demande1Toggle3)
            )
            &&
            (
                toggleIsOn(demande2Toggle1)
                || toggleIsOn(demande2Toggle2)
                || toggleIsOn(demande2Toggle3)
            )
            &&
            (
                toggleIsOn(demande3Toggle1)
                || toggleIsOn(demande3Toggle2)
                || toggleIsOn(demande3Toggle3)
            )
        ) {
            Debug.Log("display go button");
            validateButton.interactable = true;
        } else {
            Debug.Log("hide go button");
            validateButton.interactable = false;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ChangeValidateButtonOnToggleChange(demande1Toggle1);
        ChangeValidateButtonOnToggleChange(demande1Toggle2);
        ChangeValidateButtonOnToggleChange(demande1Toggle3);

        ChangeValidateButtonOnToggleChange(demande2Toggle1);
        ChangeValidateButtonOnToggleChange(demande2Toggle2);
        ChangeValidateButtonOnToggleChange(demande2Toggle3);

        ChangeValidateButtonOnToggleChange(demande3Toggle1);
        ChangeValidateButtonOnToggleChange(demande3Toggle2);
        ChangeValidateButtonOnToggleChange(demande3Toggle3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CallNextQuestion(){
        demande1.text = this.dicoQuestion.currentQuestions[0].demande;
        demande2.text = this.dicoQuestion.currentQuestions[1].demande;
        demande3.text = this.dicoQuestion.currentQuestions[2].demande;
        demande1Choix1.text = this.dicoQuestion.currentQuestions[0].choix[0].texte;
        this.demande1Toggle1.ajoutScoreNature = this.dicoQuestion.currentQuestions[0].choix[0].scoreNature;
        this.demande1Toggle1.ajoutScoreTechno = this.dicoQuestion.currentQuestions[0].choix[0].scoreScience;
        this.demande1Toggle1.ajoutScoreSocial = this.dicoQuestion.currentQuestions[0].choix[0].scoreSocial;

        demande1Choix2.text = this.dicoQuestion.currentQuestions[0].choix[1].texte;
        this.demande1Toggle2.ajoutScoreNature = this.dicoQuestion.currentQuestions[0].choix[1].scoreNature;
        this.demande1Toggle2.ajoutScoreTechno = this.dicoQuestion.currentQuestions[0].choix[1].scoreScience;
        this.demande1Toggle2.ajoutScoreSocial = this.dicoQuestion.currentQuestions[0].choix[1].scoreSocial;

        demande1Choix3.text = this.dicoQuestion.currentQuestions[0].choix[2].texte;
        this.demande1Toggle3.ajoutScoreNature = this.dicoQuestion.currentQuestions[0].choix[2].scoreNature;
        this.demande1Toggle3.ajoutScoreTechno = this.dicoQuestion.currentQuestions[0].choix[2].scoreScience;
        this.demande1Toggle3.ajoutScoreSocial = this.dicoQuestion.currentQuestions[0].choix[2].scoreSocial;
        
        demande2Choix1.text = this.dicoQuestion.currentQuestions[1].choix[0].texte;
        this.demande2Toggle1.ajoutScoreNature = this.dicoQuestion.currentQuestions[1].choix[0].scoreNature;
        this.demande2Toggle1.ajoutScoreTechno = this.dicoQuestion.currentQuestions[1].choix[0].scoreScience;
        this.demande2Toggle1.ajoutScoreSocial = this.dicoQuestion.currentQuestions[1].choix[0].scoreSocial;
        
        demande2Choix2.text = this.dicoQuestion.currentQuestions[1].choix[1].texte;
        this.demande2Toggle2.ajoutScoreNature = this.dicoQuestion.currentQuestions[1].choix[1].scoreNature;
        this.demande2Toggle2.ajoutScoreTechno = this.dicoQuestion.currentQuestions[1].choix[1].scoreScience;
        this.demande2Toggle2.ajoutScoreSocial = this.dicoQuestion.currentQuestions[1].choix[1].scoreSocial;

        demande2Choix3.text = this.dicoQuestion.currentQuestions[1].choix[2].texte;
        this.demande2Toggle3.ajoutScoreNature = this.dicoQuestion.currentQuestions[1].choix[2].scoreNature;
        this.demande2Toggle3.ajoutScoreTechno = this.dicoQuestion.currentQuestions[1].choix[2].scoreScience;
        this.demande2Toggle3.ajoutScoreSocial = this.dicoQuestion.currentQuestions[1].choix[2].scoreSocial;

        demande3Choix1.text = this.dicoQuestion.currentQuestions[2].choix[0].texte;
        this.demande3Toggle1.ajoutScoreNature = this.dicoQuestion.currentQuestions[2].choix[0].scoreNature;
        this.demande3Toggle1.ajoutScoreTechno = this.dicoQuestion.currentQuestions[2].choix[0].scoreScience;
        this.demande3Toggle1.ajoutScoreSocial = this.dicoQuestion.currentQuestions[2].choix[0].scoreSocial;
        
        demande3Choix2.text = this.dicoQuestion.currentQuestions[2].choix[1].texte;
        this.demande3Toggle2.ajoutScoreNature = this.dicoQuestion.currentQuestions[2].choix[1].scoreNature;
        this.demande3Toggle2.ajoutScoreTechno = this.dicoQuestion.currentQuestions[2].choix[1].scoreScience;
        this.demande3Toggle2.ajoutScoreSocial = this.dicoQuestion.currentQuestions[2].choix[1].scoreSocial;

        demande3Choix3.text = this.dicoQuestion.currentQuestions[2].choix[2].texte;
        this.demande3Toggle3.ajoutScoreNature = this.dicoQuestion.currentQuestions[2].choix[2].scoreNature;
        this.demande3Toggle3.ajoutScoreTechno = this.dicoQuestion.currentQuestions[2].choix[2].scoreScience;
        this.demande3Toggle3.ajoutScoreSocial = this.dicoQuestion.currentQuestions[2].choix[2].scoreSocial;

        //Mettre le label de la question
        //Mettre les labels des choix
        //Mettre les score des choix dans le gestionnaire toggle
    }

    void UpdateIncrements(choixDeMedia choix, ref int incrNature, ref int incrTech, ref int incrSocial)
    {
        Toggle toggle = choix.GetComponent<Toggle>();
        if (toggle.isOn) {
            incrNature += choix.ajoutScoreNature;
            incrTech += choix.ajoutScoreTechno;
            incrSocial += choix.ajoutScoreSocial;
        }
    }

    void UncheckToggle(choixDeMedia choix)
    {
        Toggle toggle = choix.GetComponent<Toggle>();
        toggle.isOn = false;
    }

    void UncheckAllToggles()
    {
        UncheckToggle(demande1Toggle1);
        UncheckToggle(demande1Toggle2);
        UncheckToggle(demande1Toggle3);

        UncheckToggle(demande2Toggle1);
        UncheckToggle(demande2Toggle2);
        UncheckToggle(demande2Toggle3);

        UncheckToggle(demande3Toggle1);
        UncheckToggle(demande3Toggle2);
        UncheckToggle(demande3Toggle3);
    }

    public void ValidateChoices()
    {
        int incrNature = -1;
        int incrTech = -1;
        int incrSocial = -1;

        UpdateIncrements(demande1Toggle1, ref incrNature, ref incrTech, ref incrSocial);
        UpdateIncrements(demande1Toggle2, ref incrNature, ref incrTech, ref incrSocial);
        UpdateIncrements(demande1Toggle3, ref incrNature, ref incrTech, ref incrSocial);

        UpdateIncrements(demande2Toggle1, ref incrNature, ref incrTech, ref incrSocial);
        UpdateIncrements(demande2Toggle2, ref incrNature, ref incrTech, ref incrSocial);
        UpdateIncrements(demande2Toggle3, ref incrNature, ref incrTech, ref incrSocial);

        UpdateIncrements(demande3Toggle1, ref incrNature, ref incrTech, ref incrSocial);
        UpdateIncrements(demande3Toggle2, ref incrNature, ref incrTech, ref incrSocial);
        UpdateIncrements(demande3Toggle3, ref incrNature, ref incrTech, ref incrSocial);

        gameState.UpdateScores(incrNature, incrTech, incrSocial);
        gameState.avancerEtape();
    }
    public void DisplayNextStep()
    {
        UncheckAllToggles();
        if (gameState.currentStep <= 5) {
            dicoQuestion.GenerateNewQuestions();
        }
    }
}

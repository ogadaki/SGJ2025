using UnityEngine;

public class dictionnaireQuestions : MonoBehaviour
{
    public Question[] questionsEtape1;
    public Choix choix1Question1;
    public Choix choix2Question1;
    public Choix choix3Question1;

    public Choix choix1Question2;
    public Choix choix2Question2;
    public Choix choix3Question2;

    public Choix choix1Question3;
    public Choix choix2Question3;
    public Choix choix3Question3;
    public Question question1;
    public Question question2;
    public Question question3;

    public gestionnairePanelChoix gestionPanelChoix;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        questionsEtape1 = new Question[3];
        question1 = new Question();
        question2 = new Question();
        question3 = new Question();
        choix1Question1 = new Choix("Les Raisins du Squalala", 0, 1, 3);
        choix2Question1 = new Choix("La Bible", -1, -1, -1);
        choix3Question1 = new Choix("Metal Hurlant", 3, 1, 0);
        choix1Question2 = new Choix("L'hymne de nos campagnes", 0, 3, 1);
        choix2Question2 = new Choix("Musique algorithmique", 3, 0, 0);
        choix3Question2 = new Choix("Best Of CGT", 0, 0, 3);
        choix1Question3 = new Choix("Carapuce", 0, 3, 1);
        choix2Question3 = new Choix("Salameche", 3, 0, 0);
        choix3Question3 = new Choix("Yu Gi Oh", 0, 0, 3);
        question1.creerQuestion("Choisissez un livre");
        question1.ajouterChoix1(choix1Question1);
        question1.ajouterChoix2(choix2Question1);
        question1.ajouterChoix3(choix3Question1);

        question2.creerQuestion("Choisissez une chanson");
        question2.ajouterChoix1(choix1Question2);
        question2.ajouterChoix2(choix2Question2);
        question2.ajouterChoix3(choix3Question2);

        question3.creerQuestion("Votre Starter");
        question3.ajouterChoix1(choix1Question3);
        question3.ajouterChoix2(choix2Question3);
        question3.ajouterChoix3(choix3Question3);
        questionsEtape1[0] = question1;
        questionsEtape1[1] = question2;
        questionsEtape1[2] = question3;
        this.gestionPanelChoix.CallNextQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public class Question: MonoBehaviour{
        public string demande;
        public Choix[] choix = new Choix[3];

        public Question(string demande, Choix choix1, Choix choix2, Choix choix3){
            this.demande = demande;
            choix[0] = choix1;
            choix[1] = choix2;
            choix[2] = choix3;
        }
        public Question(){

        }

        public void ajouterChoix1(Choix choix1){
            this.choix[0] = choix1;
        }
        public void ajouterChoix2(Choix choix2){
            this.choix[1] = choix2;
        }
        public void ajouterChoix3(Choix choix3){
            this.choix[2] = choix3;
        }
        public void creerQuestion(string texte){
            this.demande = texte;
        }
    }

     public class Choix: MonoBehaviour{
        public string texte;
        public int scoreScience;
        public int scoreNature;
        public int scoreSocial;

        public Choix(string choix, int scoreS, int scoreN, int scoreSoc){
            this.texte = choix;
            this.scoreNature = scoreN;
            this.scoreScience = scoreS;
            this.scoreSocial = scoreSoc;
        }
    }
}

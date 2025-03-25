using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class dictionnaireQuestions : MonoBehaviour
{
    public List<Choix> choixNature { get; private set; }
    public List<Choix> choixSocial { get; private set; }
    public List<Choix> choixTech { get; private set; }
    public List<Choix> choixAll { get; private set; }
    public Question[] currentQuestions;
    public Question question1;
    public Question question2;
    public Question question3;

    public gestionnairePanelChoix gestionPanelChoix;

    public static T GetAndRemoveRandom<T>(List<T> list)
    {
        int index = Random.Range(0, (list.Count-1));
        T item = list[index];
        list.RemoveAt(index);
        return item;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        choixNature = new List<Choix>
        {
            new Choix("La Théorie des Nuages", 1, 0, 0),
            new Choix("Les Yeux de la Terre", 1, 0, 0),
            new Choix("Le Dernier Printemps", 1, 0, 0),
            new Choix("Les Veilleurs du désert", 1, 0, 0),
            new Choix("Murmures sous la Canopée", 1, 0, 0),
            new Choix("Échos du Grand Fleuve", 1, 0, 0),
            new Choix("Les Jardins du vivant", 1, 0, 0),
            new Choix("La Fabrique du Printemps", 1, 0, 0),
            new Choix("Le Cycle des Saisons", 1, 0, 0),
            new Choix("La Mémoire des Océans", 1, 0, 0),
            new Choix("Le Chant de la Forêt", 1, 0, 0),
            new Choix("Les Montagnes d'Antan", 1, 0, 0),
            new Choix("L'Odyssée de la Graine", 1, 0, 0),
            new Choix("Le clan des loups", 1, 0, 0),
            new Choix("Le Pouls de la Terre", 1, 0, 0)
        };

        choixTech = new List<Choix>
        {
            new Choix("L'Âge des Machines", 0, 1, 0),
            new Choix("Prothèses de l'Âme", 0, 1, 0),
            new Choix("L'IA : Rêve et Réalité", 0, 1, 0),
            new Choix("Mémoire et Données", 0, 1, 0),
            new Choix("Le Grand Vertige Numérique", 0, 1, 0),
            new Choix("L'Intelligence Biologique", 0, 1, 0),
            new Choix("La machine consciente", 0, 1, 0),
            new Choix("Les Enfants de l'IA", 0, 1, 0),
            new Choix("Chroniques des Augmentés", 0, 1, 0),
            new Choix("L'Homme aux Robots", 0, 1, 0),
            new Choix("Le Transhumanisme", 0, 1, 0),
            new Choix("Les Fictions du Progrès", 0, 1, 0),
            new Choix("Réparer le Futur", 0, 1, 0),
            new Choix("Le Grandes Machines", 0, 1, 0),
            new Choix("Les Robots Rêvent-ils ?", 0, 1, 0)
        };

        choixSocial = new List<Choix>
        {
            new Choix("Les Architectes du Lien", 0, 0, 1),
            new Choix("Mémoires d'un Village", 0, 0, 1),
            new Choix("Psychologie de l'espace", 0, 0, 1),
            new Choix("L'Équilibre des Foules", 0, 0, 1),
            new Choix("Une Poignée de Main", 0, 0, 1),
            new Choix("Fragments d'un Partage", 0, 0, 1),
            new Choix("Cartographie du social", 0, 0, 1),
            new Choix("Les Marchands de Joie", 0, 0, 1),
            new Choix("Le Bruit des Connexions", 0, 0, 1),
            new Choix("Les Cercles Sociaux", 0, 0, 1),
            new Choix("Résolution des conflits", 0, 0, 1),
            new Choix("Ce qui nous Lie", 0, 0, 1),
            new Choix("Dernière Conversation", 0, 0, 1),
            new Choix("L'Expérience du Contact", 0, 0, 1),
            new Choix("Théorie de l'Entraide", 0, 0, 1)
        };

        choixAll = choixNature.Concat(choixTech).Concat(choixSocial).ToList();
        GenerateNewQuestions();
    }

    public void resetDico(){
        choixNature = new List<Choix>
        {
            new Choix("La Théorie des Nuages", 1, 0, 0),
            new Choix("Les Yeux de la Terre", 1, 0, 0),
            new Choix("Le Dernier Printemps", 1, 0, 0),
            new Choix("Les Veilleurs du désert", 1, 0, 0),
            new Choix("Murmures sous la Canopée", 1, 0, 0),
            new Choix("Échos du Grand Fleuve", 1, 0, 0),
            new Choix("Les Jardins du vivant", 1, 0, 0),
            new Choix("La Fabrique du Printemps", 1, 0, 0),
            new Choix("Le Cycle des Saisons", 1, 0, 0),
            new Choix("La Mémoire des Océans", 1, 0, 0),
            new Choix("Le Chant de la Forêt", 1, 0, 0),
            new Choix("Les Montagnes d'Antan", 1, 0, 0),
            new Choix("L'Odyssée de la Graine", 1, 0, 0),
            new Choix("Le clan des loups", 1, 0, 0),
            new Choix("Le Pouls de la Terre", 1, 0, 0)
        };

        choixTech = new List<Choix>
        {
            new Choix("L'Âge des Machines", 0, 1, 0),
            new Choix("Prothèses de l'Âme", 0, 1, 0),
            new Choix("L'IA : Rêve et Réalité", 0, 1, 0),
            new Choix("Mémoire et Données", 0, 1, 0),
            new Choix("Le Grand Vertige Numérique", 0, 1, 0),
            new Choix("L'Intelligence Biologique", 0, 1, 0),
            new Choix("La machine consciente", 0, 1, 0),
            new Choix("Les Enfants de l'IA", 0, 1, 0),
            new Choix("Chroniques des Augmentés", 0, 1, 0),
            new Choix("L'Homme aux Robots", 0, 1, 0),
            new Choix("Le Transhumanisme", 0, 1, 0),
            new Choix("Les Fictions du Progrès", 0, 1, 0),
            new Choix("Réparer le Futur", 0, 1, 0),
            new Choix("Le Grandes Machines", 0, 1, 0),
            new Choix("Les Robots Rêvent-ils ?", 0, 1, 0)
        };

        choixSocial = new List<Choix>
        {
            new Choix("Les Architectes du Lien", 0, 0, 1),
            new Choix("Mémoires d'un Village", 0, 0, 1),
            new Choix("Psychologie de l'espace", 0, 0, 1),
            new Choix("L'Équilibre des Foules", 0, 0, 1),
            new Choix("Une Poignée de Main", 0, 0, 1),
            new Choix("Fragments d'un Partage", 0, 0, 1),
            new Choix("Cartographie du social", 0, 0, 1),
            new Choix("Les Marchands de Joie", 0, 0, 1),
            new Choix("Le Bruit des Connexions", 0, 0, 1),
            new Choix("Les Cercles Sociaux", 0, 0, 1),
            new Choix("Résolution des conflits", 0, 0, 1),
            new Choix("Ce qui nous Lie", 0, 0, 1),
            new Choix("Dernière Conversation", 0, 0, 1),
            new Choix("L'Expérience du Contact", 0, 0, 1),
            new Choix("Théorie de l'Entraide", 0, 0, 1)
        };

        choixAll = choixNature.Concat(choixTech).Concat(choixSocial).ToList();
        GenerateNewQuestions();
    }

    public void GenerateNewQuestions()
    {
        currentQuestions = new Question[3];

        question1 = new Question();
        question2 = new Question();
        question3 = new Question();

        question1.creerQuestion("Choisissez un livre");
        question1.ajouterChoix1(GetAndRemoveRandom(choixNature));
        question1.ajouterChoix2(GetAndRemoveRandom(choixTech));
        question1.ajouterChoix3(GetAndRemoveRandom(choixSocial));

        question2.creerQuestion("Choisissez une chanson");
        question2.ajouterChoix1(GetAndRemoveRandom(choixNature));
        question2.ajouterChoix2(GetAndRemoveRandom(choixTech));
        question2.ajouterChoix3(GetAndRemoveRandom(choixSocial));

        question3.creerQuestion("Choisissez un film");
        question3.ajouterChoix1(GetAndRemoveRandom(choixNature));
        question3.ajouterChoix2(GetAndRemoveRandom(choixTech));
        question3.ajouterChoix3(GetAndRemoveRandom(choixSocial));

        currentQuestions[0] = question1;
        currentQuestions[1] = question2;
        currentQuestions[2] = question3;

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

        public Choix(string choix, int scoreN, int scoreS, int scoreSoc){
            this.texte = choix;
            this.scoreNature = scoreN;
            this.scoreScience = scoreS;
            this.scoreSocial = scoreSoc;
        }
    }
}

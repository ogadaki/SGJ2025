using UnityEngine;

public class gestionnaireSonsNature : MonoBehaviour
{
    public GameObject sonsNature;
    public AudioHelper audioHelper;
    public float fadeTime = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activerSourceSon(int level){
        if(level < 2){
            StartCoroutine(AudioHelper.FadeOut(sonsNature.GetComponent<AudioSource>(), fadeTime));
        }
        else{
            StartCoroutine(AudioHelper.FadeIn(sonsNature.GetComponent<AudioSource>(), fadeTime));
        }
    }
}

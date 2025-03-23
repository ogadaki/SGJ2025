using UnityEngine;

public class gestionnaireSons : MonoBehaviour
{
    public GameObject sons_niveau_0;
    public GameObject sons_niveau_1;
    public GameObject sons_niveau_2;
    public GameObject sons_niveau_3;

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

    public void activerSourceSon(int niveau){
        switch(niveau){
            case 0:
                if(sons_niveau_0.GetComponent<AudioSource>() != null){
                    StartCoroutine(AudioHelper.FadeIn(sons_niveau_0.GetComponent<AudioSource>(), fadeTime));
                }
                if(sons_niveau_1.GetComponent<AudioSource>() != null){
                    StartCoroutine(AudioHelper.FadeOut(sons_niveau_1.GetComponent<AudioSource>(), fadeTime));
                }
                if(sons_niveau_2.GetComponent<AudioSource>() != null){
                    StartCoroutine(AudioHelper.FadeOut(sons_niveau_2.GetComponent<AudioSource>(), fadeTime));
                }
                if(sons_niveau_3.GetComponent<AudioSource>() != null){
                    StartCoroutine(AudioHelper.FadeOut(sons_niveau_3.GetComponent<AudioSource>(), fadeTime));
                }
                break;
            case 1:
                if(sons_niveau_0.GetComponent<AudioSource>() != null){
                    StartCoroutine(AudioHelper.FadeOut(sons_niveau_0.GetComponent<AudioSource>(), fadeTime));
                }
                if(sons_niveau_1.GetComponent<AudioSource>() != null){
                    StartCoroutine(AudioHelper.FadeIn(sons_niveau_1.GetComponent<AudioSource>(), fadeTime));
                }
                if(sons_niveau_2.GetComponent<AudioSource>() != null){
                    StartCoroutine(AudioHelper.FadeOut(sons_niveau_2.GetComponent<AudioSource>(), fadeTime));
                }
                if(sons_niveau_3.GetComponent<AudioSource>() != null){
                    StartCoroutine(AudioHelper.FadeOut(sons_niveau_3.GetComponent<AudioSource>(), fadeTime));
                }
                break;
            case 2:
                if(sons_niveau_0.GetComponent<AudioSource>() != null){
                    StartCoroutine(AudioHelper.FadeOut(sons_niveau_0.GetComponent<AudioSource>(), fadeTime));
                }
                if(sons_niveau_1.GetComponent<AudioSource>() != null){
                    StartCoroutine(AudioHelper.FadeOut(sons_niveau_1.GetComponent<AudioSource>(), fadeTime));
                }
                if(sons_niveau_2.GetComponent<AudioSource>() != null){
                    StartCoroutine(AudioHelper.FadeIn(sons_niveau_2.GetComponent<AudioSource>(), fadeTime));
                }
                if(sons_niveau_3.GetComponent<AudioSource>() != null){
                    StartCoroutine(AudioHelper.FadeOut(sons_niveau_3.GetComponent<AudioSource>(), fadeTime));
                }
                break;
            case 3:
                if(sons_niveau_0.GetComponent<AudioSource>() != null){
                    StartCoroutine(AudioHelper.FadeOut(sons_niveau_0.GetComponent<AudioSource>(), fadeTime));
                }
                if(sons_niveau_1.GetComponent<AudioSource>() != null){
                    StartCoroutine(AudioHelper.FadeOut(sons_niveau_1.GetComponent<AudioSource>(), fadeTime));
                }
                if(sons_niveau_2.GetComponent<AudioSource>() != null){
                    StartCoroutine(AudioHelper.FadeOut(sons_niveau_2.GetComponent<AudioSource>(), fadeTime));
                }
                if(sons_niveau_3.GetComponent<AudioSource>() != null){
                    StartCoroutine(AudioHelper.FadeIn(sons_niveau_3.GetComponent<AudioSource>(), fadeTime));
                }
                break;
            default: 
                break;
        }
    }
}

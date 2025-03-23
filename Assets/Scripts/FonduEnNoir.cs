using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FonduEnNoir : MonoBehaviour
{
    // Dur�e du fondu
    public float fadeDuration = 1f; 
    private Image panelImage;
    public GameState gameState;
    void Start()
    {
        panelImage = GetComponent<Image>();
        FadeFromBlack();
    }

    public void FadeToBlack()
    {
        // De transparent � noir

        StartCoroutine(Fade(0f, 1f)); 
    }

    public void FadeFromBlack()
    {
        // De noir � transparent
        StartCoroutine(Fade(1f, 0f)); 
    }

    /// <summary>
    /// A appeler pour la transition apr�s la validation des choix du joueur.
    /// </summary>
    public void FadeToBlackThenFromBlack()
    {
        // De transparent � noir, � transparent
        StartCoroutine(FadeThenUnfade(0f, 1f));
    }

    IEnumerator FadeThenUnfade(float startAlpha, float targetAlpha)
    {
        float elapsedTime = 0f;
        Color color = panelImage.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeDuration);
            panelImage.color = color;
            yield return null;
        }

        color.a = targetAlpha;
        panelImage.color = color;
        // On attend quelques secondes avec l'�cran noir.
        yield return new WaitForSeconds(2f);
        foreach(gestionnaireMarqueur objetTemoin in gameState.gestionnaireObjetsTemoins)
        {
                objetTemoin.checkChangementEtat(gameState.GetNatureLevel());
        }
        gameState.lancerGameOver();
        FadeFromBlack();
    }

    IEnumerator Fade(float startAlpha, float targetAlpha)
    {
        float elapsedTime = 0f;
        Color color = panelImage.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeDuration);
            panelImage.color = color;
            yield return null;
        }
        color.a = targetAlpha;
        panelImage.color = color;
    }
}

using System.Collections;
using UnityEngine;

public class AudioHelper : MonoBehaviour
{
    float volMax = 0.5f;
    public static IEnumerator FadeOut(AudioSource audioSource, float fadeTime) {
        float startVolume = audioSource.volume;
        while (audioSource.volume > 0) {
            audioSource.volume -= startVolume * Time.deltaTime / fadeTime;
            yield return null;
        }
        audioSource.Stop();
    }

    public static IEnumerator Lower(AudioSource audioSource, float fadeTime, float volumeToGo) {
        float startVolume = audioSource.volume;
        while (audioSource.volume > volumeToGo) {
            audioSource.volume -= startVolume * Time.deltaTime / fadeTime;
            yield return null;
        }
    }

    public static IEnumerator FadeIn(AudioSource audioSource, float fadeTime) {
        audioSource.Play();
        audioSource.volume = 0f;
        while (audioSource.volume < 1) {
            audioSource.volume += Time.deltaTime / fadeTime;
            yield return null;
        }
    }

    public static IEnumerator Higher(AudioSource audioSource, float fadeTime, float volumeToGo) {
        while (audioSource.volume < volumeToGo) {
            audioSource.volume += Time.deltaTime / fadeTime;
            yield return null;
        }
    }
}

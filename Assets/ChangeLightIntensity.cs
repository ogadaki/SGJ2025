using UnityEngine;

public class ChangeLightIntensity : MonoBehaviour
{
    public Light targetLight; // Lumi�re � modifier
    public float minIntensity = 0.5f; // Intensit� minimale
    public float maxIntensity = 2.0f; // Intensit� maximale
    public float speed = 2.0f; // Vitesse de la pulsation

    private float _time;

    void Update()
    {
        if (targetLight != null)
        {
            _time += Time.deltaTime * speed;
            targetLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, (Mathf.Sin(_time) + 1) / 2);
        }
    }
}

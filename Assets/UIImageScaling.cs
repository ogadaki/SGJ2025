using UnityEngine;
using UnityEngine.UI;

public class UIImageScaling : MonoBehaviour
{
    public RectTransform targetImage; // L'image UI à modifier
    public Vector2 sizeA = new Vector2(100f, 100f); // Taille initiale
    public Vector2 sizeB = new Vector2(200f, 200f); // Taille finale
    public float interval = 0.5f; // Temps entre les changements

    private bool isExpanded = false;

    void Start()
    {
        if (targetImage != null)
        {
            targetImage.sizeDelta = sizeA;
            InvokeRepeating("ToggleSize", interval, interval);
        }
    }

    void ToggleSize()
    {
        if (targetImage != null)
        {
            targetImage.sizeDelta = isExpanded ? sizeA : sizeB;
            isExpanded = !isExpanded;
        }
    }
}

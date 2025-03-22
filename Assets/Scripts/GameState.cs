using UnityEngine;
using TMPro;

public class GameState : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI debugText;
    public static int currentLevel;
    public static int[] scores = new int[3] { 0, 0, 0 };


    void Start()
    {
        ResetValues();
    }

    void Update()
    {
        
    }

    void ResetValues()
    {
        currentLevel = 0;
        scores = new int[3] { 0, 0, 0 };
        UpdateDebugDisplay();
    }

    void UpdateDebugDisplay()
    {
        debugText.text =
            $"current level : {currentLevel}\n"
            + $"scores[0] : {scores[0]}\n"
            + $"scores[1] : {scores[1]}\n"
            + $"scores[2] : {scores[2]}\n"
            ;
    }
}

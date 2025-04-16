using UnityEngine;
using TMPro;

public class End : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScoreText;
    Score score;
    void Awake()
    {
        score = FindAnyObjectByType<Score>();
    }

    public void ShowFinalScore()
    {
        finalScoreText.text = $"Congratulations!!!\nFinal Score: {score.CalculateScore()}%";
    }
}

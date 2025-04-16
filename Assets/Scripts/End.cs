using UnityEngine;
using TMPro;

public class End : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScoreText;
    Score score;
    void Start()
    {
        score = FindAnyObjectByType<Score>();
    }

    void Update()
    {

    }

    public void ShowFinalScore()
    {
        finalScoreText.text = $"Congratulations!!!\nFinal Score: {score.CalculateScore()}%";
    }
}

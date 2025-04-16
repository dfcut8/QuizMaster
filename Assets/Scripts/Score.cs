using UnityEngine;

public class Score : MonoBehaviour
{
    int correctAnswers = 0;
    int questionsSeen = 0;

    public int GetCorrectAnswers() => correctAnswers;
    public void IncrementCorrectAnswers() => correctAnswers++;

    public int GetQuestionsSeen() => questionsSeen;

    public void IncrementQuestionsSeen() => questionsSeen++;

    void Start()
    {

    }

    void Update()
    {

    }

    public int CalculateScore()
    {
        return Mathf.RoundToInt((float)correctAnswers / questionsSeen * 100);
    }
}

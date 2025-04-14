using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToComplete = 30f;
    [SerializeField] float timeToShowAnswer = 10f;

    public bool IsAnsweringQuestion = false;
    public bool IsLoadNextQuestion = false;
    public float FillFraction;

    float timerValue;

    void Update()
    {
        UpdateTimer();
    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if (IsAnsweringQuestion)
        {
            if (timerValue > 0)
            {
                FillFraction = timerValue / timeToComplete;
            }
            else
            {
                timerValue = timeToShowAnswer;
                IsAnsweringQuestion = false;
            }
        }
        else
        {
            if (timerValue > 0)
            {
                FillFraction = timerValue / timeToShowAnswer;
            }
            else
            {
                timerValue = timeToComplete;
                IsAnsweringQuestion = true;
                IsLoadNextQuestion = true;
            }
        }
        Debug.Log($"timerValue: {timerValue}, IsAnsweringQuestion: {IsAnsweringQuestion}, FillFraction: {FillFraction}");
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }
}

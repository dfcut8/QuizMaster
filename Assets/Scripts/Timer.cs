using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToComplete = 30f;
    [SerializeField] float timeToShowAnswer = 10f;

    public bool IsAnsweringQuestion = false;

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
            if (timerValue <= 0)
            {
                timerValue = timeToShowAnswer;
                IsAnsweringQuestion = false;
            }
        }
        else
        {
            if (timerValue <= 0)
            {
                timerValue = timeToComplete;
                IsAnsweringQuestion = true;
            }
        }


        Debug.Log($"timerValue: {timerValue}, IsAnsweringQuestion: {IsAnsweringQuestion}");
    }
}

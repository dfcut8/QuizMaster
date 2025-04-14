using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToComplete = 30f;
    [SerializeField] float timeToShowAnswer = 10f;

    float timerValue;

    void Update()
    {
        UpdateTimer();
    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;
        if (timerValue <= 0)
        {
            timerValue = timeToComplete;
        }
        Debug.Log($"timerValue: {timerValue}");
    }
}

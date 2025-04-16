using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToComplete = 30f;
    [SerializeField] float timeToShowAnswer = 10f;

    public bool IsAnsweringQuestion = false;
    public bool IsLoadNextQuestion = false;
    public float FillFraction;

    float timerValue;

    Image timerImage;

    void Start()
    {
        timerImage = GetComponentInChildren<Image>();
    }
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
                timerImage.color = Color.white;
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
                Color newColor;
                if (ColorUtility.TryParseHtmlString("#00FF99", out newColor))
                {
                    timerImage.color = newColor;
                }
                FillFraction = timerValue / timeToShowAnswer;
            }
            else
            {
                timerValue = timeToComplete;
                IsAnsweringQuestion = true;
                IsLoadNextQuestion = true;
            }
        }
        // Debug.Log($"timerValue: {timerValue}, IsAnsweringQuestion: {IsAnsweringQuestion}, FillFraction: {FillFraction}");
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }
}

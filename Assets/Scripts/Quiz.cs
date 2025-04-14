using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private QuestionSO question;

    [Header("Answers")]
    [SerializeField] private GameObject[] answerButtons;

    [SerializeField] private Sprite defaultAnswerSprite;
    [SerializeField] private Sprite correctAnswerSprite;

    [Header("Timer")]
    [SerializeField] private Image timerImage;

    Timer timer;
    int correctAnswerIndex;

    public void Start()
    {
        // timer = FindAnyObjectByType<Timer>();
        timer = GetComponentInChildren<Timer>();
        GetNextQuestion();
    }

    public void Update()
    {
        timerImage.fillAmount = timer.FillFraction;
        if (timer.IsLoadNextQuestion)
        {
            GetNextQuestion();
            timer.IsLoadNextQuestion = false;
        }
    }

    public void OnAnswerSelected(int index)
    {
        if (index == question.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct!";
            Image buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        else
        {
            var correctAnswerText = question.GetAnswers()[correctAnswerIndex];
            questionText.text = $"BAD BAD BAD! :(\nCorrect answer: {correctAnswerText}";
            Image buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }

        SetButtonsState(false);
        timer.CancelTimer();
    }

    private void GetNextQuestion()
    {
        SetButtonsState(true);
        SetDefaultButtonsSprite();
        DisplayQuestion();
    }

    private void SetDefaultButtonsSprite()
    {
        foreach (var b in answerButtons)
        {
            Image buttonImage = b.GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }

    private void DisplayQuestion()
    {
        questionText.text = question.GetQuestion();
        var answers = question.GetAnswers();
        for (int i = 0; i < answerButtons.Length; i++)
        {
            var buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = answers[i];
        }
    }

    private void ToggleButtons()
    {
        foreach (var button in answerButtons)
        {
            var bComponent = button.GetComponent<Button>();
            bComponent.interactable = !bComponent.interactable;
        }
    }

    private void SetButtonsState(bool state)
    {
        foreach (var button in answerButtons)
        {
            var bComponent = button.GetComponent<Button>();
            bComponent.interactable = state;
        }
    }
}

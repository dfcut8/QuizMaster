using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private List<QuestionSO> questions = new();
    private QuestionSO currentQuestion;

    [Header("Answers")]
    [SerializeField] private GameObject[] answerButtons;

    [Header("Buttons")]
    [SerializeField] private Sprite defaultAnswerSprite;
    [SerializeField] private Sprite correctAnswerSprite;

    [Header("Timer")]
    [SerializeField] private Image timerImage;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    Score score;

    Timer timer;
    int correctAnswerIndex;
    bool hasAnsweredEarly = false;

    public void Start()
    {
        timer = GetComponentInChildren<Timer>();
        score = GetComponentInChildren<Score>();
        scoreText.text = $"Score: 0%";
    }

    public void Update()
    {
        timerImage.fillAmount = timer.FillFraction;
        if (timer.IsLoadNextQuestion)
        {
            hasAnsweredEarly = false;
            GetNextQuestion();
            timer.IsLoadNextQuestion = false;
        }
        else if (!hasAnsweredEarly && !timer.IsAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonsState(false);
        }
    }

    public void OnAnswerSelected(int index)
    {
        hasAnsweredEarly = true;
        DisplayAnswer(index);
        SetButtonsState(false);
        timer.CancelTimer();
        scoreText.text = $"Score: {score.CalculateScore()}%";
    }

    private void DisplayAnswer(int index)
    {
        if (index == currentQuestion.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct!";
            Image buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
            score.IncrementCorrectAnswers();

        }
        else
        {
            var correctAnswerText = currentQuestion.GetAnswers()[correctAnswerIndex];
            questionText.text = $"BAD BAD BAD! :(\nCorrect answer: {correctAnswerText}";
            Image buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
    }

    private void GetNextQuestion()
    {
        if (questions.Count > 0)
        {
            SetButtonsState(true);
            SetDefaultButtonsSprite();
            GetRandomQuestion();
            DisplayQuestion();
        }
        else
        {
            // end the game
        }

    }

    private void GetRandomQuestion()
    {
        int index = Random.Range(0, questions.Count);
        currentQuestion = questions[index];
        if (questions.Contains(currentQuestion))
        {
            questions.Remove(currentQuestion);
        }
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
        questionText.text = currentQuestion.GetQuestion();
        var answers = currentQuestion.GetAnswers();
        for (int i = 0; i < answerButtons.Length; i++)
        {
            var buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = answers[i];
        }
        score.IncrementQuestionsSeen();
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

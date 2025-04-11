using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Mono.Cecil;

public class Quiz : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private QuestionSO question;
    [SerializeField] private GameObject[] answerButtons;
    [SerializeField] private Sprite defaultAnswerSprite;
    [SerializeField] private Sprite correctAnswerSprite;
    private int correctAnswerIndex;

    void Start()
    {
        questionText.text = question.GetQuestion();
        var answers = question.GetAnswers();
        for (int i = 0; i < answerButtons.Length; i++)
        {
            var buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = answers[i];
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
    }
}

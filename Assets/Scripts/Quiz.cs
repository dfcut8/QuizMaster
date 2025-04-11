using UnityEngine;
using TMPro;

public class Quiz : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private QuestionSO question;
    [SerializeField] private GameObject[] answerButtons;

    void Start()
    {
        questionText.text = question.GetQuestion();
        var answers = question.GetAnswers();
        for (int i = 0; i < 4; i++)
        {
            var buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = answers[i];
        }
    }
}

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "new_question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField] private string question = "Sample question?";
    [SerializeField] private string[] answers = new string[4];
    [SerializeField] private int correctAnswerIndex = 0;

    // Getters
    public string GetQuestion() => question;
    public string[] GetAnswers() => answers;
    public int GetCorrectAnswerIndex() => correctAnswerIndex;
}
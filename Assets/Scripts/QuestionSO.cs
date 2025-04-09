using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "new_question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2,6)]
    public string Question = "Sample question?";
    public string[] Answers = new string[4];
}

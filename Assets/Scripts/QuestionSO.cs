using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "new_question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField] private string question = "Sample question?";
}

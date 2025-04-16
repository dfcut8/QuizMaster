using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Quiz quiz;
    End end;
    void Awake()
    {
        quiz = FindAnyObjectByType<Quiz>();
        end = FindAnyObjectByType<End>();
    }
    void Start()
    {
        quiz.gameObject.SetActive(true);
        end.gameObject.SetActive(false);
    }

    void Update()
    {
        if (quiz.IsCompleted)
        {
            quiz.gameObject.SetActive(false);
            end.gameObject.SetActive(true);
            end.ShowFinalScore();
        }
    }

    public void OnPlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

using UnityEngine;
using UnityEngine.EventSystems;

public class Background : MonoBehaviour, IPointerClickHandler
{
    Quiz quiz;
    Timer timer;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!timer.IsAnsweringQuestion)
        {
            Debug.Log("clicked on background while showing answer");
            timer.IsLoadNextQuestion = true;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        quiz = FindAnyObjectByType<Quiz>();
        timer = FindAnyObjectByType<Timer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

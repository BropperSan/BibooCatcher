using UnityEngine;
using TMPro;
using System;

public class GameTimer : MonoBehaviour
{
    public static event Action OnTimerEnd;
    [Header("Настройки")]
    public float timeRemaining = 90f;
    public bool timerIsRunning = false;

    [Header("UI")]
    public TMP_Text timerText;

    private void OnEnable()
    {
        timeRemaining = 90f;
        timerIsRunning = true;
    }

    private void OnDisable()
    {
        timerIsRunning = false;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerUI(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                UpdateTimerUI(timeRemaining);
                timerText.text = string.Format("00:00");
                OnTimerEnd?.Invoke();
            }
        }
    }

    void UpdateTimerUI(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
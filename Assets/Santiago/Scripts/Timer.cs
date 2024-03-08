using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timeRemaining = 10f;
    [SerializeField] private GameObject gameManager;
    private bool timerIsRunning = false;

    public TextMeshProUGUI timeText;
    public GameObject finishScreen;

    private void Start()
    {
        timerIsRunning = true;
    }

    private void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;

                UpdateTimeText(timeRemaining);
            }
            else
            {
                Debug.Log("Tiempo finalizado!");
                timeRemaining = 0;
                timerIsRunning = false;

                TimeIsUp();
            }
        }
    }

    void UpdateTimeText(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void TimeIsUp()
    {
        gameManager.GetComponent<GameManager>().FinishGame();
        finishScreen.SetActive(true);
        timeText.text = "00:00";
    }
}

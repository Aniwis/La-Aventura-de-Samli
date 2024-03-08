using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointsUI;

    private int points = 0;

    private void Start()
    {
        Time.timeScale = 1.0f;
    }

    public void AddPoint()
    {
        points++;
    }

    public void FinishGame()
    {
        Time.timeScale = 0;
        pointsUI.text = points.ToString();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}

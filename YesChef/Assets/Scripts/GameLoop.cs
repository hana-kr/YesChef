using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public enum GameState { StartMenu, Playing, FinalScreen }

public class GameManager : MonoBehaviour
{
    [SerializeField] private StartScreen startScreen;
    [SerializeField] private FinishMenu finishMenu;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI scoreText;
    public GameState state = GameState.StartMenu;

    private float endTime;
    private int score;
    private int highScore;

    void OnEnable()
    {
        startScreen.onStartClicked += StartGame;
        finishMenu.onRestartClicked += ReloadGame;

        DeliveryManager.OrderScoreUpdate += HandleScoreUpdate;
    }
    private void OnDisable()
    {
        DeliveryManager.OrderScoreUpdate -= HandleScoreUpdate;
    }

    private void HandleScoreUpdate(object sender, ScoreUpdatedEventArgs e)
    {
        score += e.Score;
        scoreText.text = score.ToString();
    }

    private void StartGame(object sender, EventArgs e)
    {
        state = GameState.Playing;
        endTime = Time.time + 180f;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }
    private void ReloadGame(object sender, EventArgs e)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void EndGame()
    {
        state = GameState.FinalScreen;
        timerText.text = "00:00";
        if (score > highScore)
    {
        highScore = score;
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.Save();
    }
    }


    void Update()
    {
        switch (state)
        {
            case GameState.StartMenu:
                startScreen.gameObject.SetActive(true);
                break;

            case GameState.Playing:
                float timeLeft = Mathf.Max(0f, endTime - Time.time);
                UpdateTimerUI(timeLeft);

                if (timeLeft <= 0f)
                {
                    EndGame();
                }
                break;

            case GameState.FinalScreen:
                finishMenu.gameObject.SetActive(true);
                finishMenu.Setup(score);
                break;
        }
    }

    private void UpdateTimerUI(float timeLeft)
    {
        int minutes = Mathf.FloorToInt(timeLeft / 60f);
        int seconds = Mathf.FloorToInt(timeLeft % 60f);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }

}
public class ScoreUpdatedEventArgs : EventArgs
{
    public int Score { get; private set; }

    public ScoreUpdatedEventArgs(int score)
    {
        Score = score;
    }
}



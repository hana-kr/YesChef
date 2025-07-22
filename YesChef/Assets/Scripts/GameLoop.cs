using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public enum GameState { StartMenu, Playing, FinalScreen }

public class GameManager : MonoBehaviour
{
    [SerializeField] private StartScreen startScreen;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI scoreText;
    public GameState state = GameState.StartMenu;

    private float endTime;
    private int score;

    void OnEnable()
    {
        startScreen.onStartClicked += StartGame;
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
    }

    private void EndGame()
    {
        state = GameState.FinalScreen;
        timerText.text = "00:00";
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



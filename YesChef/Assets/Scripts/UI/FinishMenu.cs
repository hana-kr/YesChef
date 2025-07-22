using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinishMenu : MonoBehaviour
{
    [SerializeField] Button restartButton;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;
    public event EventHandler onRestartClicked;


    public void Setup(int score)
    {
        highScoreText.text = $"High Score: {PlayerPrefs.GetInt("HighScore", 0)}";
        scoreText.text = "score : "+ score;
        Time.timeScale = 0f;
        restartButton.onClick.AddListener(OnRestartClicked);
    }

    void OnRestartClicked()
    {
        Time.timeScale = 1f;
        onRestartClicked.Invoke(this , EventArgs.Empty);
        gameObject.SetActive(false);
    }
}

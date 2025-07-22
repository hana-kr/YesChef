using System;
using UnityEngine;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    [SerializeField] Button startButton;
    public event EventHandler onStartClicked;


    void Awake()
    {
        Time.timeScale = 0f;
        startButton.onClick.AddListener(OnStartClicked);
    }

    void OnStartClicked()
    {
        Time.timeScale = 1f;
        onStartClicked.Invoke(this , EventArgs.Empty);
        gameObject.SetActive(false);
    }
}

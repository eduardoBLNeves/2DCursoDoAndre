using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager:MonoBehaviour
{
    public static GameManager Instance;
    public GameObject Player;
    public GameObject Panel;
    public TextMeshProUGUI BestScoreText;
    public TextMeshProUGUI CurrentScoreText;
    public List<GameObject> EnemiesList;
    public AudioSource pointSound;

    private void Awake()
    {
        Instance = this;
    }

    public static bool IsRunning = false;
    public static int BestScore = 0;
    public static int CurrentScore = 0;

    public void StartGame()
    {
        IsRunning = true;
        CurrentScore = 0;
        Panel.SetActive(false);
        CurrentScoreText.gameObject.SetActive(true);
        CurrentScoreText.text = "Score: 0";
    }

    public void SetScoreUp()
    {
        CurrentScore++;
        CurrentScoreText.text = "Score: "+ CurrentScore;
        pointSound.Play();
    }

    public void GameOver()
    {
        IsRunning = false;
        BestScore = CurrentScore > BestScore ? CurrentScore : BestScore;
        BestScoreText.text = "Best Score: "+CurrentScore.ToString();
        Panel.SetActive(true);
        CurrentScoreText.gameObject.SetActive(false);
        Player.GetComponent<Rigidbody2D>().position = new Vector2(0f, 0f);
        SetEnemiesPosition();
    }

    void SetEnemiesPosition()
    {
        foreach (var enemy in EnemiesList)
        {
            enemy.GetComponent<Rigidbody2D>().position = new Vector2(0f, 3.42f);
        }
    }
}

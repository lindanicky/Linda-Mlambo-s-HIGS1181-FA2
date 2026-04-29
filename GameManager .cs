using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour

{
    public static GameManager instance;

    public int totalEnemies = 5;
    private int enemiesRemaining;

    public GameObject winScreen;
    public Text enemyCounterText;
    public GameObject winPanel;

    void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       StartGame(); 
    }
    public void StartGame()
    {
        enemiesRemaining = totalEnemies;
        UpdateUI();
        winScreen.SetActive(false);
    }
    public void OnEnemyDestroyed()
    {
        enemiesRemaining--;
        UpdateUI();
        CheckWinCondition();

        if (enemiesRemaining<= 0)
        {
            CheckWinCondition();
        }
    }
    void CheckWinCondition()
    {
        ShowWinScreen();
    }
    void ShowWinScreen()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0f; //Pause Game
    }

    public void ResetGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    // Update is called once per frame
    void UpdateUI()
    {
      enemyCounterText.text = "Enemies;" + enemiesRemaining;  
    }
}


using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    [SerializeField]
    public Player player;
    [SerializeField]
    public Text scoreText;
    public bool isPause;
    public bool isPlaying;


    List<Level> levels;
    public Level currLevel;
    public int levelIdx;

    public void CheckUpLevel(int score)
    {
        if (score >= currLevel.scoreToNextLevel)
            NextLevel();
    }

    public void NextLevel()
    {
        levelIdx++;
        if (levelIdx < levels.Count)
            currLevel = levels[levelIdx];
    }

    void GenerateLevel()
    {
        levels = new List<Level>();
        levels.Add(new Level(0.50f, 0.00f, 0.00f, 0020));
        levels.Add(new Level(0.40f, 0.20f, 0.00f, 0050));
        levels.Add(new Level(0.30f, 0.10f, 0.20f, 0100));
        levels.Add(new Level(0.30f, 0.30f, 0.30f, 0150));
        levels.Add(new Level(0.10f, 0.20f, 0.40f, 0200));
        levels.Add(new Level(0.10f, 0.10f, 0.50f, 0250));
        levels.Add(new Level(0.10f, 0.30f, 0.40f, 0300));
        levels.Add(new Level(0.25f, 0.25f, 0.40f, 0350));
        levels.Add(new Level(0.25f, 0.40f, 0.40f, 0400));
    }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        SoundManager.getInstance().play_BGM_GamePlay();
        StartLevel();
    }

    void Update()
    {
        if (isPlaying)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Menu))
            {
                TooglePauseMenuPanel();
            }
        }
    }

    void StartLevel()
    {
        isPlaying = true;
        isPause = false;
        scoreText.text = "Score : 0";
        GenerateLevel();
        levelIdx = -1;
        NextLevel();
        Time.timeScale = 1;
        player.AddScore(10);

    }

    public void GoToMainMenu()
    {
        isPause = false;
        GameManager.Instance.GoToMainMenu();
    }

    public void RestartLevel()
    {
        GameManager.Instance.GotoGameplay();
    }

    public void GotoDeadScene(int score)
    {
        isPlaying = false;
        isPause = true;
        ShowGameOverPanel();

    }

    [SerializeField]
    GameObject gameOverPanel;
    [SerializeField]
    Text finalScoreText;
    [SerializeField]
    Text highScoreText;
    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
        int hs = GameManager.Instance.GetHighScore();
        finalScoreText.text =
            "Your Score : " + player.score + "\n" +
            "High Score : " + hs + "\n"
            ;
        highScoreText.text = "";
        if (player.score > hs)
        {
            GameManager.Instance.SetHighScore(player.score);
            SoundManager.getInstance().play_sFX_HiScore();
            highScoreText.text = "NEW HIGH SCORE!";
        }
        else
            SoundManager.getInstance().play_sFX_Lose();


    }

    [SerializeField]
    GameObject pauseMenuPanel;
    public void TooglePauseMenuPanel()
    {
        if (isPlaying)
        {
            isPause = !isPause;
            Time.timeScale = (isPause) ? 0 : 1;
            pauseMenuPanel.SetActive(isPause);

        }
    }


}

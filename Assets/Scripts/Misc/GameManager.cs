using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    [SerializeField]
    public int currLevel;

    // Use this for initialization
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            DontDestroyOnLoad(gameObject);

        }
        else if (Instance != this)
            Destroy(gameObject);



        if (!PlayerPrefs.HasKey("comic"))
            PlayerPrefs.SetInt("comic", 0);
        if (!PlayerPrefs.HasKey("HS"))
            PlayerPrefs.SetInt("HS", 0);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GotoGameplay()
    {
        if (!PlayerPrefs.HasKey("comic"))
            PlayerPrefs.SetInt("comic", 0);
        int comic = PlayerPrefs.GetInt("comic");
        if (comic == 1)
            SceneManager.LoadScene("Gameplay");
        else
            SceneManager.LoadScene("Komik");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public int GetHighScore()
    {
        if (!PlayerPrefs.HasKey("HS"))
            PlayerPrefs.SetInt("HS", 0);
        return PlayerPrefs.GetInt("HS");
    }

    public void SetHighScore(int score)
    {
        PlayerPrefs.SetInt("HS", score);
        PlayerPrefs.Save();
    }

    public void DeleteAllData()
    {
        PlayerPrefs.DeleteAll();
    }

}

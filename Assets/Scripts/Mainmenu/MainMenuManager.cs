using UnityEngine;
using System.Collections;

public class MainMenuManager : MonoBehaviour
{

    public static MainMenuManager Instance;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        SoundManager.getInstance().play_BGM_MainMenu();
    }

	public void GoToGameplay()
    {
        GameManager.Instance.GotoGameplay();
    }
    public void Quit()
    {
        GameManager.Instance.Quit();
    }

    public void DeleteAllData()
    {
        GameManager.Instance.DeleteAllData();
    }
}

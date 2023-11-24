using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField]
    private GameObject levelFailPanel;
    [SerializeField]
    private GameObject levelCompletePanel;
    [SerializeField]
    private GameObject startPanel;
    private void Awake()
    {
       Time.timeScale = 0;
        if (instance == null)
        {
            instance = this;
        }
    }
    public void OnLevelFail()
    {
        levelFailPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        BallBehaviour.isGameOver = false;
        levelFailPanel.SetActive(false);
        SceneManager.LoadScene("GamePlay");
    }
    public void OnLevelComplete()
    {
        levelCompletePanel.SetActive(true);
    }
    public void StartGame()
    {
        Time.timeScale = 1f;
        startPanel.SetActive(false);
    }
}

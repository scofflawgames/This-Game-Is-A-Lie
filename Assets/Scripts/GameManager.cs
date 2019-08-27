using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Public References")]
    public GameObject pauseMenu;
    public GameObject matrixFalls;
    public GameObject hud;
    public TextMeshProUGUI scoreText;

    [Header("Public Variables")]
    public static bool isPaused = false;
    public static int score;

    private void Awake()
    {
        matrixFalls.SetActive(true);
        hud.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                PauseGame();
            }
            else
            {
                UnPauseGame();
            }
        }
    }

    public void ScoreUpdate()
    {
        scoreText.text = ("SCORE: " + score);
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        isPaused = true;
        Time.timeScale = 0;
    }

    public void UnPauseGame()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        if (Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}

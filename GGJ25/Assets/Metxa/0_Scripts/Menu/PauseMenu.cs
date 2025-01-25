using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    private SightController hitter;
    public GameObject m_PauseMenu;//, m_DeathMenu;

    private void Start()
    {
        hitter = GetComponent<SightController>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))// && !m_DeathMenu.activeSelf)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        m_PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        hitter.stop = false;
    }
    void Pause()
    {
        m_PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        hitter.stop = true;
    }
    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void CloseApplication()
    {
        Application.Quit();
    }
}

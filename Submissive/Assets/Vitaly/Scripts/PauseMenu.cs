using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    [Header("Для появляющейся после нажатия кнопки")]
    public GameObject musicButton;

    // Подпишите на этот ивент свой метод открытия двери при выключении звука в настройках
    // Пример:
    // |Объект скрипта PauseMenu|.DisabledSounds += |Написанный в вашем классе метод открывания двери|
    // _pauseMenu.DisabledSounds += OpenDoor;
    public event Action DisabledSounds;
    [SerializeField] private string _prompt;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Button_Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Button_Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    private void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Button_Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");

    }

    public void Button_Exit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void ButtonDisableMusic()
    {
        gameObject.SetActive(false);
        AudioListener.pause = true;
        musicButton.SetActive(true);
        DisabledSounds?.Invoke();
    }

    public void ButtonEnableMusic()
    {
        gameObject.SetActive(false);
        AudioListener.pause = false;
        musicButton.SetActive(true);
    }
}

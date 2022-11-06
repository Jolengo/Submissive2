using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public object ScenceManager { get; private set; }

    public void NewGame(string gameScene)
    {
        SceneManager.LoadScene(gameScene);
    }

    public void Exit()
    {
        Application.Quit();
    }
    public void Retry(string gameScene)
    {
        SceneManager.LoadScene(gameScene);
    }

    public void Menu(string gameScene)
    {
        SceneManager.LoadScene(gameScene);
    }
}

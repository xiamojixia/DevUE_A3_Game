using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OpenLevelSelectPage()
    {
        SceneManager.LoadScene("LevelSelectPage");
    }

    public void OpenHelp()
    {
        SceneManager.LoadScene("HelpPage");
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene("SettingPage");
    }

    public void OpenLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OpenLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void OpenLevel3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void BackToLevelSelect()
    {
        SceneManager.LoadScene("LevelSelectPage");
    }

    public void QuitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
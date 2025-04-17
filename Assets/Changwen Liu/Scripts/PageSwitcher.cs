using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public float delayBeforeLoad = 0.2f;

    public void OpenLevelSelectPage()
    {
        StartCoroutine(LoadSceneWithDelay("LevelSelectPage"));
    }

    public void OpenHelp()
    {
        StartCoroutine(LoadSceneWithDelay("HelpPage"));
    }

    public void OpenSettings()
    {
        StartCoroutine(LoadSceneWithDelay("SettingPage"));
    }

    public void OpenLevel1()
    {
        StartCoroutine(LoadSceneWithDelay("Level1"));
    }

    public void OpenLevel2()
    {
        StartCoroutine(LoadSceneWithDelay("Level2"));
    }

    public void OpenLevel3()
    {
        StartCoroutine(LoadSceneWithDelay("Level3"));
    }

    public void BackToMenu()
    {
        StartCoroutine(LoadSceneWithDelay("MainMenu"));
    }

    public void BackToLevelSelect()
    {
        StartCoroutine(LoadSceneWithDelay("LevelSelectPage"));
    }

    public void QuitGame()
    {
        StartCoroutine(QuitAfterDelay());
    }

    private IEnumerator LoadSceneWithDelay(string sceneName)
    {
        yield return new WaitForSeconds(delayBeforeLoad);
        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator QuitAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeLoad);
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
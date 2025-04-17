using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicSelector : MonoBehaviour
{
    void Start()
    {
        if (AudioManager.Instance == null) return;

        string sceneName = SceneManager.GetActiveScene().name;

        switch (sceneName)
        {
            case "MainMenu":
            case "LevelSelectPage":
                AudioManager.Instance.PlayMusic(AudioManager.Instance.mainMenuMusic);
                break;
            case "Level1":
                AudioManager.Instance.PlayMusic(AudioManager.Instance.level1Music);
                break;
            case "Level2":
                AudioManager.Instance.PlayMusic(AudioManager.Instance.level2Music);
                break;
            case "Level3":
                AudioManager.Instance.PlayMusic(AudioManager.Instance.level3Music);
                break;
            default:
                break;
        }
    }
}
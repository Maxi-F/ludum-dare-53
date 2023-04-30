using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static void LoadSceneMainMenu() 
    {
        SceneManager.LoadScene("MainMenu");       
    }

    public static void LoadSceneHowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public static void LoadSceneCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public static void LoadSceneIntro()
    {
        SceneManager.LoadScene("Intro");
    }

    public static void LoadSceneGameplay()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public static void LoadSceneEndScreen()
    {
        SceneManager.LoadScene("EndScreen");
    }

    public static void QuitGame()
    {
        Application.Quit();
    }
}
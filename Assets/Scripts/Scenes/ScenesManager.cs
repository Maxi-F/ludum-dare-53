using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static void LoadSceneMainMenu() 
    {
        Cursor.visible = true;
        SceneManager.LoadScene("MainMenu");       
    }

    public static void LoadSceneHowToPlay()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("HowToPlay");
    }

    public static void LoadSceneCredits()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("Credits");
    }

    public static void LoadSceneIntro()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("Intro");
    }

    public static void LoadSceneGameplay()
    {
        Cursor.visible = false;
        SceneManager.LoadScene("Main Game");
    }

    public static void LoadSceneEndScreen()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("EndScreen");
    }

    public static void QuitGame()
    {
        Cursor.visible = true;
        Application.Quit();
    }
}
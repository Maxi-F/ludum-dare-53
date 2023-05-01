using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void Click(string name)
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        
        switch (name)
        {
            case "MainMenu":
                audioManager.Play("Click");
                ScenesManager.LoadSceneMainMenu();
                break;
            case "HowToPlay":
                audioManager.Play("Click");
                ScenesManager.LoadSceneHowToPlay();
                break;
            case "Credits":
                audioManager.Play("Click");
                ScenesManager.LoadSceneCredits();
                break;
            case "Intro":
                audioManager.StopAll();
                audioManager.Play("Click");
                audioManager.Play("Ilustraciones_intro");
                ScenesManager.LoadSceneIntro();
                break;
            case "Gameplay":
                ScenesManager.LoadSceneGameplay();
                break;
            case "EndScreen":
                ScenesManager.LoadSceneEndScreen();
                break;
            case "Quit":
                ScenesManager.QuitGame();
                break;
            default:
                Debug.LogWarning("Scene " + name + "not found.");
                break;
        }
    }
}

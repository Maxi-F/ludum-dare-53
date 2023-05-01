using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound sound in sounds)
        {
            sound.GenerateAudioSource(gameObject.AddComponent<AudioSource>());
        }
    }

    private void Start()
    {
        Play("Intro_outro");
    }

    public void Play (string name)
    {
        Sound soundToPlay = FindSound(name);
        if (soundToPlay == null) return;

        soundToPlay.Play();
    }

    public void Stop (string name)
    {
        Sound soundToStop = FindSound(name);
        if (soundToStop == null) return;

        soundToStop.Stop();
    }

    public void StopAll()
    {
        foreach (Sound sound in sounds)
        {
            sound.Stop();
        }
    }
    private Sound FindSound (string name)
    {
        Sound foundSound = Array.Find(sounds, sound => sound.name == name);

        if (foundSound == null)
        {
            Debug.LogWarning("Sound " + name + " does not exist");
            return null;
        }

        return foundSound;
    }
}

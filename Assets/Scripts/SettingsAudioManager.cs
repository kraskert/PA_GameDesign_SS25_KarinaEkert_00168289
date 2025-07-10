using UnityEngine;

public class SettingsAudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource soundSource;

    public void ToggleMusic(bool isOn)
    {
        if (musicSource != null)
            musicSource.mute = !isOn;
    }

    public void ToggleSound(bool isOn)
    {
        if (soundSource != null)
            soundSource.mute = !isOn;
    }
}
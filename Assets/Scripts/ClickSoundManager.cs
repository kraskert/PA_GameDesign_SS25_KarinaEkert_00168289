using UnityEngine;

public class ClickSoundManager : MonoBehaviour
{
    public AudioSource clickAudioSource;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (clickAudioSource != null)
                clickAudioSource.Play();
        }
    }
}
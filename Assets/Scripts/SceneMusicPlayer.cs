using UnityEngine;

public class SceneMusicPlayer : MonoBehaviour
{
    public AudioClip musicClip;
    public bool loop = true;

    private AudioSource audioSource;

    void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = musicClip;
        audioSource.loop = loop;
        audioSource.playOnAwake = false;

        audioSource.Play();
    }
}
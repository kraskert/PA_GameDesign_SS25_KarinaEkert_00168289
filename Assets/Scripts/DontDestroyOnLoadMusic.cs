using UnityEngine;

public class DontDestroyOnLoadMusic : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
using UnityEngine;

public class Level2StartManager : MonoBehaviour
{
    public GameObject level2Panel1;
    public GameObject level2Bubble1;

    void Start()
    {
        if (level2Panel1 != null)
            level2Panel1.SetActive(true);

        if (level2Bubble1 != null)
            level2Bubble1.SetActive(true);
    }
}
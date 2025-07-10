using UnityEngine;

public class GameEndTrigger : MonoBehaviour
{
    public GameObject finalMessageBubble;
    public float delay = 10f;

    void Start()
    {
        StartCoroutine(ShowFinalMessage());
    }

    System.Collections.IEnumerator ShowFinalMessage()
    {
        yield return new WaitForSeconds(delay);
        finalMessageBubble.SetActive(true);
    }
}
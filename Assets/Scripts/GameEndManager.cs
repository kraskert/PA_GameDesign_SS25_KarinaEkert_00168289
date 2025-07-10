using UnityEngine;

public class GameEndManager : MonoBehaviour
{
    public GameObject finalMessageBubble;
    private int remainingObjects = 0;

    void Awake()
    {
        finalMessageBubble.SetActive(false);
    }

    public void RegisterObject()
    {
        remainingObjects++;
    }

    public void ObjectDestroyed()
    {
        remainingObjects--;

        if (remainingObjects <= 0)
        {
            finalMessageBubble.SetActive(true);
        }
    }
}
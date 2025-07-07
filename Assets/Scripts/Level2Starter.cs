using UnityEngine;

public class Level2Starter : MonoBehaviour
{
    public GameObject brokenNucleusPanel;
    public GameObject explanationBubble1;

    void Start()
    {
        if (brokenNucleusPanel != null)
            brokenNucleusPanel.SetActive(true);

        if (explanationBubble1 != null)
            explanationBubble1.SetActive(true);
    }
}

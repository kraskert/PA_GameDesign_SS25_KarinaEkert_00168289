using UnityEngine;

public class PanelAdvanceOnClick : MonoBehaviour
{
    public GameObject currentPanel;
    public GameObject currentBubble;

    public GameObject nextPanel;
    public GameObject nextBubble;

    public void Advance()
    {
        if (currentPanel != null)
            currentPanel.SetActive(false);

        if (currentBubble != null)
            currentBubble.SetActive(false);

        if (nextPanel != null)
            nextPanel.SetActive(true);

        if (nextBubble != null)
            nextBubble.SetActive(true);
    }
}
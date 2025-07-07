using UnityEngine;

public class DropZoneManager : MonoBehaviour
{
    public int totalCorrectParts = 7;
    private int correctPartsPlaced = 0;

    public GameObject greatJobPanel;

    public static bool levelCompleted = false;

    public void RegisterCorrectDrop()
    {
        if (levelCompleted) return; // Prevent counting after completion

        correctPartsPlaced++;

        if (correctPartsPlaced >= totalCorrectParts)
        {
            levelCompleted = true;
            ShowGreatJobPanel();
        }
    }

    private void ShowGreatJobPanel()
    {
        if (greatJobPanel == null) return;

        CanvasGroup cg = greatJobPanel.GetComponent<CanvasGroup>();
        if (cg != null)
        {
            cg.alpha = 1f;
            cg.interactable = true;
            cg.blocksRaycasts = true;
        }
        else
        {
            greatJobPanel.SetActive(true);
        }
    }
}
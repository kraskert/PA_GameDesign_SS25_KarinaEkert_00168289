using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    [HideInInspector]
    public Vector3 originalPosition;

    [HideInInspector]
    public bool correctlyDropped = false;

    public GameObject oopsMessage;
    public GameObject instructionPanel;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        originalPosition = rectTransform.localPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
{
    if (DropZoneManager.levelCompleted) return;

    canvasGroup.alpha = 0.6f;
    canvasGroup.blocksRaycasts = false;
}

    public void OnDrag(PointerEventData eventData)
    {
        if (correctlyDropped) return; // Prevent dragging if already correctly dropped

        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
{
    if (DropZoneManager.levelCompleted) return;

    canvasGroup.alpha = 1f;
    canvasGroup.blocksRaycasts = true;

    if (!correctlyDropped)
    {
        rectTransform.localPosition = originalPosition;
        ShowOopsMessage();
    }
}

    void ShowOopsMessage()
{
    if (DropZoneManager.levelCompleted) return;

    // Block if GreatJob panel is active
    GameObject greatJob = GameObject.Find("GreatJob_Panel");
    if (greatJob != null && greatJob.activeSelf)
    {
        return; // Stop here — level is complete
    }

    GameObject explanation = GameObject.Find("Explanation_Bubble");
    if (explanation != null)
        explanation.SetActive(false); // Hide explanation while showing Oops

    if (oopsMessage == null) return;

    CanvasGroup cg = oopsMessage.GetComponent<CanvasGroup>();
    if (cg == null) return;

    StopAllCoroutines();
    StartCoroutine(ShowOopsCoroutine(cg));
}

    System.Collections.IEnumerator ShowOopsCoroutine(CanvasGroup cg)
    {
        cg.alpha = 1f;
        yield return new WaitForSeconds(1.5f);
        cg.alpha = 0f;

        // After hiding Oops, show the instruction panel again
        if (instructionPanel != null)
        {
            instructionPanel.SetActive(true);
        }
        else
        {
            GameObject explanation = GameObject.Find("Explanation_Bubble");
            if (explanation != null) explanation.SetActive(true);
        }
    }
}
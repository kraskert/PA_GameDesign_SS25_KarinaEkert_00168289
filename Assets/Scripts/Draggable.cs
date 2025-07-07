using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    [HideInInspector]
    public Vector3 originalPosition;

    private Vector3 startPosition;

    [HideInInspector]
    public bool correctlyDropped = false;

    public GameObject oopsMessage;

    public GameObject instructionPanel;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        originalPosition = rectTransform.localPosition;
        startPosition = transform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
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

        GameObject explanation = GameObject.Find("Explanation_Bubble");
        if (explanation != null) explanation.SetActive(false);

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
    }
}
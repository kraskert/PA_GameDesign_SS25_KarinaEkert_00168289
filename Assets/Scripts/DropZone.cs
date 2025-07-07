using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
{
    Draggable draggable = eventData.pointerDrag.GetComponent<Draggable>();

    if (draggable != null)
    {
        // Disable the instruction panel after first drop attempt
        if (draggable.instructionPanel != null && draggable.instructionPanel.activeSelf)
        {
            draggable.instructionPanel.SetActive(false);
        }

        if (eventData.pointerDrag.CompareTag("CorrectPart"))
        {
            // Correct drop
            draggable.correctlyDropped = true;
            
            FindAnyObjectByType<DropZoneManager>()?.RegisterCorrectDrop();
        }
        else
        {
            // Incorrect drop — show Oops! temporarily
            if (draggable.oopsMessage != null)
            {
                draggable.oopsMessage.SetActive(true);
                draggable.StartCoroutine(HideOopsAfterSeconds(draggable.oopsMessage, 2f));
            }

            // Return to start position
            draggable.transform.localPosition = draggable.originalPosition;
        }
    }
}

    private System.Collections.IEnumerator HideOopsAfterSeconds(GameObject message, float delay)
    {
        yield return new WaitForSeconds(delay);
        message.SetActive(false);
    }
}
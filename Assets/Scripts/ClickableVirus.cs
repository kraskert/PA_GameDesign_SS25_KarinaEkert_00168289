using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableVirus : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Destroy(gameObject);
    }
}
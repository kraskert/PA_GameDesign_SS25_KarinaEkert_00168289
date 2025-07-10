using UnityEngine;

public class PanelToggle : MonoBehaviour
{
    public void TogglePanel()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
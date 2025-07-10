using UnityEngine;

public class ClickAnywhereManager : MonoBehaviour
{
    public GameObject finalMessageBubble;
    private bool finalShown = false;

    void Start()
    {
        if (finalMessageBubble != null)
            finalMessageBubble.SetActive(false);
    }

    void Update()
    {
        if (finalShown) return;

        // Wait until all moving objects are gone
        int remaining = GameObject.FindGameObjectsWithTag("Virus").Length +
                        GameObject.FindGameObjectsWithTag("BloodCell").Length +
                        GameObject.FindGameObjectsWithTag("Macrophage").Length;

        if (remaining > 0) return;

        if (Input.GetMouseButtonDown(0))
        {
            finalShown = true;

            if (finalMessageBubble != null)
                finalMessageBubble.SetActive(true);

            this.enabled = false;
        }
    }
}
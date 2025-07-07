using UnityEngine;

public class PatchClickManager : MonoBehaviour
{
    public GameObject panel2;
    public GameObject bubble2;
    public GameObject patch; 
    public GameObject panel3;
    public GameObject bubble3;

    public void OnPatchClicked()
    {
        if (panel2 != null) panel2.SetActive(false);
        if (bubble2 != null) bubble2.SetActive(false);
        if (patch != null) patch.SetActive(false); // Hide the patch after click

        if (panel3 != null) panel3.SetActive(true);
        if (bubble3 != null) bubble3.SetActive(true);
    }

    public void ShowSecondStep()
    {
        if (panel2 != null) panel2.SetActive(true);
        if (bubble2 != null) bubble2.SetActive(true);
        if (patch != null) patch.SetActive(true); // Show the patch
    }
}
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SimpleFinalManager : MonoBehaviour
{
    public Sprite[] panels; // Panel images
    public Sprite[] texts; // Text bubble images
    public Image displayImage; // UI Image to show panels
    public Image textImage; // UI Image to show text bubbles

    private int currentIndex = 0;

    void Start()
    {
        displayImage.sprite = panels[currentIndex];
        if (texts[currentIndex] != null)
{
    textImage.sprite = texts[currentIndex];
    textImage.enabled = true;
}
else
{
    textImage.enabled = false;
}
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Advance();
        }
    }

    void Advance()
    {
        currentIndex++;

        if (currentIndex < panels.Length)
        {
            displayImage.sprite = panels[currentIndex];
            if (texts[currentIndex] != null)
{
    textImage.sprite = texts[currentIndex];
    textImage.enabled = true;
}
else
{
    textImage.enabled = false;
}
        }
        else
        {
            SceneManager.LoadScene("StartPage");
        }
    }
}
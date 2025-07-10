using UnityEngine;
using UnityEngine.UI;

public class Swimmer : MonoBehaviour
{
    public RectTransform target;
    public float speed = 50f;

    private RectTransform rectTransform;
    private bool isMoving = true;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();

        // Register with GameEndManager
        GameEndManager manager = FindFirstObjectByType<GameEndManager>();
        if (manager != null)
        {
            manager.RegisterObject();
        }
        else
        {
            Debug.LogWarning("GameEndManager not found — object not registered.");
        }
    }

    void Update()
    {
        if (!isMoving) return;

        Vector3 direction = target.position - rectTransform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
            rectTransform.position = target.position;
            isMoving = false;
        }
        else
        {
            rectTransform.position += direction.normalized * distanceThisFrame;
        }
    }

    public void StopSwimming()
    {
        isMoving = false;
    }
}
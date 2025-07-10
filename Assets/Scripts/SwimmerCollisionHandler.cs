using UnityEngine;

public class SwimmerCollisionHandler : MonoBehaviour
{
    public GameEndManager endManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Virus") || other.CompareTag("BloodCell") || other.CompareTag("Macrophage"))
        {
            if (endManager != null)
            {
                endManager.ObjectDestroyed();
            }
            Destroy(other.gameObject);
        }
    }
}
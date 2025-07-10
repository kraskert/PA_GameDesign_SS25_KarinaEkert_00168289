using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatStarter : MonoBehaviour
{
    public List<Swimmer> swimmers;

    public float minDelay = 0.3f;
    public float maxDelay = 1.0f;

    public void StartFloating() 
    {
        StartCoroutine(StartFloatingSequence());
    }

    IEnumerator StartFloatingSequence()
    {
        foreach (Swimmer swimmer in swimmers)
{
    if (swimmer != null)
    {
        swimmer.enabled = true; // Only enable if the object wasn't destroyed
        float waitTime = Random.Range(minDelay, maxDelay);
        yield return new WaitForSeconds(waitTime);
    }
}
    }
}
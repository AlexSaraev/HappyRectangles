using System.Collections;
using UnityEngine;

public class DoubleClickDestroyer : MonoBehaviour
{
    // === PROPERTIES === 
    float firstClickTime = 0;
    float timeBetweenClicks = 0.3f;
    bool coroutineAllowed = true;
    int clickCounter = 0;

    // === METHODS ===
    void OnMouseDown()
    {
        clickCounter++;

        if (clickCounter == 1 && coroutineAllowed)
        {
            firstClickTime = Time.time;
            StartCoroutine(DoubleClickDetection());
        }
    }

    IEnumerator DoubleClickDetection()
    {
        coroutineAllowed = false;

        while (Time.time < firstClickTime + timeBetweenClicks)
        {
            if (clickCounter == 2)
            {
                Destroy(gameObject);
                yield break;
            }
            yield return new WaitForEndOfFrame();
        }
        clickCounter = 0;
        firstClickTime = 0;
        coroutineAllowed = true;
    }
}

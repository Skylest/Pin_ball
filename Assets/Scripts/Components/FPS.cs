using System.Collections;
using UnityEngine;

public class FPS : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(FpsUnlock());        
    }

    IEnumerator FpsUnlock()
    {
        while (true)
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 9999;
            yield return null;
        }
    }
}

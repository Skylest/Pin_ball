using System.Collections;
using UnityEngine;

/// <summary>
///  ласс реализовывающий разблокировку максимального FPS
/// </summary>
public class FpsUnlocker : MonoBehaviour
{
    /// <summary>
    /// Ёкземпл€р FpsUnlocker
    /// </summary>
    private static FpsUnlocker instance;

    private void Awake()
    {
        // ѕровер€ем, существует ли уже экземпл€р FpsUnlocker
        if (instance != null && instance != this)
        {
            // ≈сли экземпл€р уже существует и это не текущий объект, уничтожаем его
            Destroy(gameObject);
            return;
        }

        // —охран€ем текущий экземпл€р FpsUnlocker
        instance = this;

        // ƒелаем этот объект неуничтожаемым при загрузке новых сцен
        DontDestroyOnLoad(gameObject);
    }

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

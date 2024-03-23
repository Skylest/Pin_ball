using System.Collections;
using UnityEngine;

/// <summary>
/// ����� ��������������� ������������� ������������� FPS
/// </summary>
public class FpsUnlocker : MonoBehaviour
{
    /// <summary>
    /// ��������� FpsUnlocker
    /// </summary>
    private static FpsUnlocker instance;

    private void Awake()
    {
        // ���������, ���������� �� ��� ��������� FpsUnlocker
        if (instance != null && instance != this)
        {
            // ���� ��������� ��� ���������� � ��� �� ������� ������, ���������� ���
            Destroy(gameObject);
            return;
        }

        // ��������� ������� ��������� FpsUnlocker
        instance = this;

        // ������ ���� ������ �������������� ��� �������� ����� ����
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

using System.Collections;
using UnityEngine;

/// <summary>
/// ����� ��������������� �������� ����������� ������
/// </summary>
public class DestroyAnimation : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Scale());
    }

    /// <summary>
    /// �������� ���������� ������ �� ������
    /// </summary>
    IEnumerator Scale()
    {
        float tolerance = 0.05f;
        float scaleStep = 0.002f;

        float x = gameObject.transform.localScale.x;
        float y = gameObject.transform.localScale.y;

        while (x > tolerance)
        {
            x -= scaleStep;
            y -= scaleStep;
            gameObject.transform.localScale = new Vector3(x, y, 1);
            yield return new WaitForSecondsRealtime(8f/1000);
        }

        Destroy(gameObject);
    }
}

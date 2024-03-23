using System.Collections;
using UnityEngine;

/// <summary>
/// ����� ��������������� �������� � ����
/// </summary>
public class BottomTrigerAnimate : MonoBehaviour
{
    /// <summary>
    /// ������ �� ���
    /// </summary>
    [SerializeField] private GameObject ball;

    /// <summary>
    /// ������ �� Rigidbody ����
    /// </summary>
    [SerializeField] private Rigidbody2D ballRigidbody;

    /// <summary>
    /// ���� ������� �������� ����������� ����
    /// </summary>
    private bool waitStart = false;

    /// <summary>
    /// ������� ��� ������ ����
    /// </summary>
    private readonly float ballXPos = 1.9f, ballYPos = 4.09f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball") && !waitStart)
        {
            waitStart = true;
            ballRigidbody.velocity = Vector2.zero;
            StartCoroutine(WaitRestartAnim());
        }
    }

    /// <summary>
    /// �������� ��� �������� ����
    /// </summary>
    IEnumerator WaitRestartAnim()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        ball.transform.position = new Vector2(Random.Range(-ballXPos, ballXPos), ballYPos);
        waitStart = false;
    }
}

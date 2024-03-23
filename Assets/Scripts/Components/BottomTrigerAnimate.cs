using System.Collections;
using UnityEngine;

/// <summary>
///  ласс реализовывающий анимацию в меню
/// </summary>
public class BottomTrigerAnimate : MonoBehaviour
{
    /// <summary>
    /// —сылка на м€ч
    /// </summary>
    [SerializeField] private GameObject ball;

    /// <summary>
    /// —сылка на Rigidbody м€ча
    /// </summary>
    [SerializeField] private Rigidbody2D ballRigidbody;

    /// <summary>
    /// ‘лаг запуска ожидани€ перемещени€ м€ча
    /// </summary>
    private bool waitStart = false;

    /// <summary>
    /// ѕозиции дл€ спавна м€ча
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
    /// ќжидани€ дл€ респавна м€ча
    /// </summary>
    IEnumerator WaitRestartAnim()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        ball.transform.position = new Vector2(Random.Range(-ballXPos, ballXPos), ballYPos);
        waitStart = false;
    }
}

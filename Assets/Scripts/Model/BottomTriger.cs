using UnityEngine;

/// <summary>
/// ����� ��������������� ��������� ������� ����
/// </summary>
public class BottomTriger : MonoBehaviour
{
    /// <summary>
    /// ������ �� GameController
    /// </summary>
    [SerializeField] private GameController gameController;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!GlobalParams.pause)
        {
            if (collision.gameObject.CompareTag("Ball"))
            {
                gameController.OnLose();
            }
        }
    }
}

using UnityEngine;

/// <summary>
/// ����� ��������������� ����� ����� ������ � �����
/// </summary>
public class GameController : MonoBehaviour
{
    /// <summary>
    /// ������ �� ������
    /// </summary>
    [SerializeField] private GameModel gameModel;

    /// <summary>
    /// ������ �� ������ ��� ���������
    /// </summary>
    [SerializeField] private GameObject afterGame;

    private void Start()
    {
        GlobalParams.pause = false;
        afterGame.SetActive(false);
    }

    /// <summary>
    /// ���������� ����
    /// </summary>
    public void Restart()
    {
        afterGame.SetActive(false);
        AdvertisementManager.Instance.CheckRestarts();
        GlobalParams.pause = false;
        gameModel.StartGame();
    }

    /// <summary>
    /// ������ ��� ����������� ����
    /// </summary>
    /// <param name="destroyedTarget">����������� ������</param>
    public void OnDestroyTarget(GameObject destroyedTarget)
    {
        gameModel.AddScore(destroyedTarget);
    }

    /// <summary>
    /// �������� (������� ����)
    /// </summary>
    public void OnLose()
    {
        GlobalParams.pause = true;
        gameModel.EndGame();
        UserOptions.Instance.SaveOptions();
        afterGame.SetActive(true);        
    }
}

using UnityEngine;

/// <summary>
/// Класс реализовывающий связь между вводом и игрой
/// </summary>
public class GameController : MonoBehaviour
{
    /// <summary>
    /// Ссылка на модель
    /// </summary>
    [SerializeField] private GameModel gameModel;

    /// <summary>
    /// Ссылка на канвас при проиграше
    /// </summary>
    [SerializeField] private GameObject afterGame;

    private void Start()
    {
        GlobalParams.pause = false;
        afterGame.SetActive(false);
    }

    /// <summary>
    /// Перезапуск игры
    /// </summary>
    public void Restart()
    {
        afterGame.SetActive(false);
        AdvertisementManager.Instance.CheckRestarts();
        GlobalParams.pause = false;
        gameModel.StartGame();
    }

    /// <summary>
    /// Логика при уничтожении цели
    /// </summary>
    /// <param name="destroyedTarget">Уничтоженый объект</param>
    public void OnDestroyTarget(GameObject destroyedTarget)
    {
        gameModel.AddScore(destroyedTarget);
    }

    /// <summary>
    /// Проиграш (падение мяча)
    /// </summary>
    public void OnLose()
    {
        GlobalParams.pause = true;
        gameModel.EndGame();
        UserOptions.Instance.SaveOptions();
        afterGame.SetActive(true);        
    }
}

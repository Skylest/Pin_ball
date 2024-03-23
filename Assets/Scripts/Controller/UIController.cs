using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Класс реализовывающий свзяь UI и ввода
/// </summary>
public class UIController : MonoBehaviour
{    
    /// <summary>
    /// Ссылка на класс смены языка
    /// </summary>
    [SerializeField] private LangChanger langChanger;

    /// <summary>
    /// Массив TxtController текстовых объектов меню
    /// </summary>
    [SerializeField] private TxtController[] txtController;

    private void Update()
    {
        //Обработка кнопки Back
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name == "Menu")
            {
                Application.Quit();
            }
            else
            {
                SceneManager.LoadScene("Menu");
                GlobalParams.pause = true;
                AdvertisementManager.Instance.CheckBackToMenu();
            }
        }
    }

    /// <summary>
    /// Возврат в меню
    /// </summary>
    public void BackToMenu()
    {
        LoadMenuScene();
    }

    /// <summary>
    /// Запуск первого режима (один мяч)
    /// </summary>
    public void ClickPlay1()
    {
        GlobalParams.pause = false;
        GlobalParams.gameMode = 1;
        LoadGameScene();
    }

    /// <summary>
    /// Запуск второго режима (два мячя)
    /// </summary>
    public void ClickPlay2()
    {
        GlobalParams.pause = false;
        GlobalParams.gameMode = 2;
        LoadGameScene();
    }

    /// <summary>
    /// Выход из игры
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }

    /// <summary>
    /// Смена настроек звука и музыки
    /// </summary>
    public void ClickOnSoundButton()
    {
        MusicPlayer.Instance.ChangeSoundOptions();
        UserOptions.Instance.SaveOptions();
    }

    /// <summary>
    /// Смена языка
    /// </summary>
    public void ChangeLand()
    {
        langChanger.ChangeLang();
        UserOptions.Instance.SaveOptions();

        for(int i = 0; i < txtController.Length; i++)        
            txtController[i].SetLang();        
    }

    /// <summary>
    /// Загрузка меню
    /// </summary>
    private void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }

    /// <summary>
    /// Загрузка игровой сцены
    /// </summary>
    private void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }
}

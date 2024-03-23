using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ����� ��������������� ����� UI � �����
/// </summary>
public class UIController : MonoBehaviour
{    
    /// <summary>
    /// ������ �� ����� ����� �����
    /// </summary>
    [SerializeField] private LangChanger langChanger;

    /// <summary>
    /// ������ TxtController ��������� �������� ����
    /// </summary>
    [SerializeField] private TxtController[] txtController;

    private void Update()
    {
        //��������� ������ Back
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
    /// ������� � ����
    /// </summary>
    public void BackToMenu()
    {
        LoadMenuScene();
    }

    /// <summary>
    /// ������ ������� ������ (���� ���)
    /// </summary>
    public void ClickPlay1()
    {
        GlobalParams.pause = false;
        GlobalParams.gameMode = 1;
        LoadGameScene();
    }

    /// <summary>
    /// ������ ������� ������ (��� ����)
    /// </summary>
    public void ClickPlay2()
    {
        GlobalParams.pause = false;
        GlobalParams.gameMode = 2;
        LoadGameScene();
    }

    /// <summary>
    /// ����� �� ����
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }

    /// <summary>
    /// ����� �������� ����� � ������
    /// </summary>
    public void ClickOnSoundButton()
    {
        MusicPlayer.Instance.ChangeSoundOptions();
        UserOptions.Instance.SaveOptions();
    }

    /// <summary>
    /// ����� �����
    /// </summary>
    public void ChangeLand()
    {
        langChanger.ChangeLang();
        UserOptions.Instance.SaveOptions();

        for(int i = 0; i < txtController.Length; i++)        
            txtController[i].SetLang();        
    }

    /// <summary>
    /// �������� ����
    /// </summary>
    private void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }

    /// <summary>
    /// �������� ������� �����
    /// </summary>
    private void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }
}

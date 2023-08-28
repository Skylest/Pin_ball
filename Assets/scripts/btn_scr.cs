using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class btn_scr : MonoBehaviour
{
    [SerializeField]
    Sprite musOn, musOff;

    [SerializeField]
    GameObject afterGame;

    [SerializeField]
    Ads ad;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            if (PlayerPrefs.GetInt("mus") == 1)
            {
                GameObject.Find("Button_Mus").GetComponent<Image>().sprite = musOn;
            }
            else
            {
                GameObject.Find("Button_Mus").GetComponent<Image>().sprite = musOff;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name == "Menu")
            {
                Application.Quit();
            }
            else
            {
                SceneManager.LoadScene("Menu");
                CsGlobal.pause = true;
                ad.CheckBackToMenu();
            }
        }
    }

    public void Restart()
    {
        afterGame.transform.gameObject.SetActive(false);
        ad.CheckRestarts();
        CsGlobal.pause = false;
        creator.StartGame();

    }

    public void BackToMenu()
    {
        Invoke(nameof(MainMenu), 1f);
        ad.CheckBackToMenu();
    }

    public void Play1()
    {
        Invoke(nameof(Game), 1f);
        CsGlobal.pause = false;
        CsGlobal.gameMode = 1;
    }

    public void Play2()
    {
        Invoke(nameof(Game), 0f);
        CsGlobal.pause = false;
        CsGlobal.gameMode = 2;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Music()
    {
        if (PlayerPrefs.GetInt("mus") == 1)
        {
            PlayerPrefs.SetInt("mus", 0);
            GameObject.Find("Button_Mus").GetComponent<Image>().sprite = musOff; 
            AudioListener.pause = true;
        }
        else 
        {
            PlayerPrefs.SetInt("mus", 1);
            GameObject.Find("Button_Mus").GetComponent<Image>().sprite = musOn;
            AudioListener.pause = false;
        }
        PlayerPrefs.Save();
    }

    private void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void Game()
    {
        SceneManager.LoadScene("Game");
    }
}

using UnityEngine;
using UnityEngine.Advertisements;

public class CsGlobal : MonoBehaviour
{

    public static int gameMode = 1;
    public static bool pause = true;


    void Start()
    {
        if (!PlayerPrefs.HasKey("record1"))
        {
            PlayerPrefs.SetInt("record1", 0);
        }
        if (!PlayerPrefs.HasKey("record2"))
        {
            PlayerPrefs.SetInt("record2", 0);
        }
        if (!PlayerPrefs.HasKey("mus"))
        {
            PlayerPrefs.SetInt("mus", 1);
        }
        if (!PlayerPrefs.HasKey("lang"))
        {
            PlayerPrefs.SetString("lang", Application.systemLanguage.ToString());
            PlayerPrefs.Save();
        }        
        if (PlayerPrefs.GetInt("mus") == 1)
        {
            AudioListener.pause = false;
        }
        else
        {
            AudioListener.pause = true;
        }
    }
}

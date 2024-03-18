using System;
using UnityEngine;

public class UserOptions : MonoBehaviour
{
    private void Awake()
    {
        GlobalParams.record1 = PlayerPrefs.GetInt("record1", 0);
        GlobalParams.record2 = PlayerPrefs.GetInt("record2", 0);
        GlobalParams.sound = bool.Parse(PlayerPrefs.GetString("sound", "true"));
        
        Enum.TryParse(PlayerPrefs.GetString("lang", Application.systemLanguage.ToString()), out SystemLanguage systemLang);
        GlobalParams.lang = systemLang;
    }

    /// <summary>
    /// Сохраняет текущие параметры
    /// </summary>
    public void SaveOptions()
    {
        PlayerPrefs.SetInt("record1", GlobalParams.record1);
        PlayerPrefs.SetInt("record2", GlobalParams.record2);
        PlayerPrefs.SetString("sound", GlobalParams.sound.ToString());
        PlayerPrefs.SetString("lang", GlobalParams.lang.ToString());
    }
}
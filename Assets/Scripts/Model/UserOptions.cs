using System;
using UnityEngine;

/// <summary>
/// Класс реализовывающий управление опциями
/// </summary>
public class UserOptions : MonoBehaviour
{
    /// <summary>
    /// Экземпляр AdvertisementManager
    /// </summary>
    private static UserOptions instance;

    /// <summary>
    /// Получение единственного экземпляра AdvertisementManager
    /// </summary>
    public static UserOptions Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        // Проверяем, существует ли уже экземпляр UserOptions
        if (instance != null && instance != this)
        {
            // Если экземпляр уже существует и это не текущий объект, уничтожаем его
            Destroy(gameObject);
            return;
        }

        // Сохраняем текущий экземпляр UserOptions
        instance = this;

        // Делаем этот объект неуничтожаемым при загрузке новых сцен
        DontDestroyOnLoad(gameObject);

        //Установка параметров из опций при инициализации
        GlobalParams.record1 = PlayerPrefs.GetInt("record1", 0);
        GlobalParams.record2 = PlayerPrefs.GetInt("record2", 0);
        GlobalParams.sound = bool.Parse(PlayerPrefs.GetString("sound", "true"));

        Enum.TryParse(PlayerPrefs.GetString("lang", Application.systemLanguage.ToString()), out SystemLanguage systemLang);
        GlobalParams.lang = systemLang;
    }

    /// <summary>
    /// Сохранение текущих параметров
    /// </summary>
    public void SaveOptions()
    {
        PlayerPrefs.SetInt("record1", GlobalParams.record1);
        PlayerPrefs.SetInt("record2", GlobalParams.record2);
        PlayerPrefs.SetString("sound", GlobalParams.sound.ToString());
        PlayerPrefs.SetString("lang", GlobalParams.lang.ToString());
        PlayerPrefs.Save();
    }
}
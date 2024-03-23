using System;
using System.Linq;
using UnityEngine;

/// <summary>
/// Класс реализовывающий управление сменой языка среди досутпных
/// </summary>
public class LangChanger : MonoBehaviour
{
    /// <summary>
    /// Массив доступных языков
    /// </summary>
    private readonly string[] queue = { "English", "Ukrainian", "Russian", "German", "Spanish", "French" };

    /// <summary>
    /// Индекс текущего языка
    /// </summary>
    private static int currentIndex = -1;

    private void Start()
    {
        string lang = GlobalParams.lang.ToString();

        if (queue.Contains(lang))
            currentIndex = Array.IndexOf(queue, lang);
        else
        {
            //Установка английского если язык системы не поддерживается
            currentIndex = 0;
            Enum.TryParse(queue[currentIndex], out SystemLanguage systemLang);
            GlobalParams.lang = systemLang;
        }
    }

    /// <summary>
    /// Смена языка не следующий в массиве
    /// </summary>
    public void ChangeLang()
    {
        if (currentIndex == queue.Length - 1)
        {
            currentIndex = 0;
        }
        else
        {
            currentIndex++;
        }
        Enum.TryParse(queue[currentIndex], out SystemLanguage systemLang);
        GlobalParams.lang = systemLang;
    }
}

using System;
using System.Linq;
using UnityEngine;

/// <summary>
/// ����� ��������������� ���������� ������ ����� ����� ���������
/// </summary>
public class LangChanger : MonoBehaviour
{
    /// <summary>
    /// ������ ��������� ������
    /// </summary>
    private readonly string[] queue = { "English", "Ukrainian", "Russian", "German", "Spanish", "French" };

    /// <summary>
    /// ������ �������� �����
    /// </summary>
    private static int currentIndex = -1;

    private void Start()
    {
        string lang = GlobalParams.lang.ToString();

        if (queue.Contains(lang))
            currentIndex = Array.IndexOf(queue, lang);
        else
        {
            //��������� ����������� ���� ���� ������� �� ��������������
            currentIndex = 0;
            Enum.TryParse(queue[currentIndex], out SystemLanguage systemLang);
            GlobalParams.lang = systemLang;
        }
    }

    /// <summary>
    /// ����� ����� �� ��������� � �������
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

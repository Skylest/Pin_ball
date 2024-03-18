using UnityEngine;

/// <summary>
/// Глобальные параметры игры
/// </summary>
public static class GlobalParams
{
    /// <summary>
    /// Текущий режим игры
    /// </summary>
    public static int gameMode = 1;

    /// <summary>
    /// Флаг паузы
    /// </summary>
    public static bool pause = false;

    /// <summary>
    /// Флаг звука
    /// </summary>
    public static bool sound = true;

    /// <summary>
    /// Рекорд в первом режиме
    /// </summary>
    public static int record1 = 0;

    /// <summary>
    /// Рекорд во втором режиме
    /// </summary>
    public static int record2 = 0;

    /// <summary>
    /// Текущий язык
    /// </summary>
    public static SystemLanguage lang = 0;
}

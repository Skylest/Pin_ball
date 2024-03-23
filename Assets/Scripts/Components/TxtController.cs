using TMPro;
using UnityEngine;

/// <summary>
/// Класс реализовывающий управление текстом в объекте
/// </summary>
public class TxtController : MonoBehaviour
{
    /// <summary>
    /// Тексты для каждого доступного языка
    /// </summary>
    public string ru, ua, de, es, en, fr;
    
    private TextMeshProUGUI objectText;

    private void Start()
    {
        objectText = GetComponent<TextMeshProUGUI>();
        SetLang();
    }

    /// <summary>
    /// Установка текста на объект в зависимости от языка
    /// </summary>
    public void SetLang()
    {
        string lang = GlobalParams.lang.ToString();
        objectText.text = lang switch
        {
            "Russian" => ru,
            "Ukrainian" => ua,
            "French" => fr,
            "German" => de,
            "Spanish" => es,
            "English" => en,
            _ => en,
        };
    }
}

using TMPro;
using UnityEngine;

/// <summary>
/// ����� ��������������� ���������� ������� � �������
/// </summary>
public class TxtController : MonoBehaviour
{
    /// <summary>
    /// ������ ��� ������� ���������� �����
    /// </summary>
    public string ru, ua, de, es, en, fr;
    
    private TextMeshProUGUI objectText;

    private void Start()
    {
        objectText = GetComponent<TextMeshProUGUI>();
        SetLang();
    }

    /// <summary>
    /// ��������� ������ �� ������ � ����������� �� �����
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

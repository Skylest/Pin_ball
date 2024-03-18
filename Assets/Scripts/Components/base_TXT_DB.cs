using TMPro;
using UnityEngine;

public class base_TXT_DB : MonoBehaviour
{
    public string ru, ua, de, es, en, fr;
    private static string[] queue = { "Russian", "Ukrainian", "English", "German", "Spanish", "French" };
    private static int inc = 0;

    private void Awake()
    {
        if (this.gameObject.name == "Text_Lang")
        {
            checkLang();
        }
        SetLeng();
    }

    public void SetLeng()
    {
        string lang = PlayerPrefs.GetString("lang");
        gameObject.GetComponent<TextMeshProUGUI>().text = lang switch
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

    public void checkLang()
    {
        for (int i = 0; i < queue.Length; i++)
        {
            if (queue[i] == PlayerPrefs.GetString("lang"))
            {
                inc = i;
                break;
            }
        }
    }

    public void ChangeLang()
    {
        if (inc == queue.Length - 1)
        {
            inc = 0;
        }
        else
        {
            inc++;
        }
        PlayerPrefs.SetString("lang", queue[inc]);
        SetLeng();
    }
}

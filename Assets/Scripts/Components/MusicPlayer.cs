using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Класс реализовывающий управление музыкой и звуками
/// </summary>
public class MusicPlayer : MonoBehaviour
{
    /// <summary>
    /// Экземпляр MusicPlayer
    /// </summary>
    private static MusicPlayer instance;

    /// <summary>
    /// Получение единственного экземпляра MusicPlayer
    /// </summary>
    public static MusicPlayer Instance
    {
        get { return instance; }
    }

    /// <summary>
    /// Звук при клике
    /// </summary>
    [SerializeField] private AudioClip soundOnClick;

    /// <summary>
    /// Ссылка на спрайт кнопки звука
    /// </summary>
    [SerializeField] private Image soundButton;

    /// <summary>
    /// Спрайты состояний кнопки
    /// </summary>
    [SerializeField] private Sprite musOn, musOff;

    private AudioSource audioSource;

    private void Awake()
    {
        // Проверяем, существует ли уже экземпляр MusicManager
        if (instance != null && instance != this)
        {
            // Если экземпляр уже существует и это не текущий объект, уничтожаем его
            Destroy(gameObject);
            return;
        }

        // Сохраняем текущий экземпляр MusicManager
        instance = this;

        // Делаем этот объект неуничтожаемым при загрузке новых сцен
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        OnChangedSoundOptions();
    }

    /// <summary>
    /// Проигрывание звука при клике
    /// </summary>
    public void PlaySoundOnClick()
    {
        audioSource.PlayOneShot(soundOnClick);
    }

    /// <summary>
    /// Включение/отключения звуков и музыки
    /// </summary>
    public void ChangeSoundOptions()
    {
        GlobalParams.sound = !GlobalParams.sound;
        OnChangedSoundOptions();
    }

    /// <summary>
    /// Изменение параметров объектов при изменении настроек
    /// </summary>
    private void OnChangedSoundOptions()
    {
        audioSource.mute = !GlobalParams.sound;

        if (GlobalParams.sound)
        {
            audioSource.UnPause();
            soundButton.sprite = musOn;
        }

        else
        {
            audioSource.Pause();
            soundButton.sprite = musOff;
        }
    }
}


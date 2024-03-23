using UnityEngine;

/// <summary>
/// Класс реализовывающий связь между кнопками и MusicPlayer
/// </summary>
public class SoundController : MonoBehaviour
    {
    /// <summary>
    /// Проигрывание звука при клике
    /// </summary>
    public void PlaySoundOnClick()
    {
        MusicPlayer.Instance.PlaySoundOnClick();
    }
}


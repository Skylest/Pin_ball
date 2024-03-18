using UnityEngine;

public class MusPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip soundOnClick;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
        audioSource.mute = GlobalParams.sound;
        
        if(!GlobalParams.sound) 
            audioSource.Pause();
        else 
            audioSource.Play();
    }
}


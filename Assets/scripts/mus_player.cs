using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mus_player : MonoBehaviour
{
    static int musID = 13;
    static bool musRand = false;
    [SerializeField]
    AudioClip [] music = new AudioClip [15];

    void Start()
    {
        if (!musRand)
        {
            musID = Random.Range(0, music.Length-1);
            musRand = true;
        }

        GetComponent<AudioSource>().clip = music[musID];
        GetComponent<AudioSource>().Play();
        musID++;
        if (musID >= music.Length)
        {
            musID = 0;
        }
        StartCoroutine(nameof(Wait));
    }

    IEnumerator Wait()
    {
        while (true)
        {
            yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
            GetComponent<AudioSource>().clip = music[musID];
            GetComponent<AudioSource>().Play();
            musID++;
            if (musID >= music.Length)
            {
                musID = 0;
            }
        }
    }
}

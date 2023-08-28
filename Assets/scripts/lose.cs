using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lose : MonoBehaviour
{
    public GameObject AfterGame;
    private bool start = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!CsGlobal.pause && SceneManager.GetActiveScene().name == "Game")
        {
            if (CsGlobal.gameMode == 2 || collision.gameObject.name == "Ball1")
            {
                GameObject.Find("Ball1").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                GameObject.Find("Ball2").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                if (CsGlobal.gameMode == 2 && PlayerPrefs.GetInt("record2") < creator.score)
                {
                    PlayerPrefs.SetInt("record2", creator.score);
                    PlayerPrefs.Save();
                }
                else
                {
                    if (PlayerPrefs.GetInt("record1") < creator.score)
                    {
                        PlayerPrefs.SetInt("record1", creator.score);
                        PlayerPrefs.Save();
                    }
                }
                AfterGame.transform.gameObject.SetActive(true);
                CsGlobal.pause = true;
            }
        }
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            if (collision.gameObject.name == "Ball1")
            {
                GameObject.Find("Ball1").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                if (start)
                {
                    StartCoroutine(nameof(Wait));
                    start = false;
                }
            }
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.5f);
        GameObject.Find("Ball1").transform.position = new Vector3(Random.Range(-1.9f, 1.9f), 4.09f, 0f);
        start = true;
    }
}

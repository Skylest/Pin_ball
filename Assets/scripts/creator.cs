using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class creator : MonoBehaviour
{
    public static int max = 3, count = 0, score = 0;
    public static List<GameObject> targetList = new List<GameObject>();
    public Material[] color = new Material[14];
    private GameObject template, parent;
    private static GameObject txtScore, txtRecord;



    private void Start()
    {
        targetList.Clear();
        template = GameObject.Find("_template").gameObject;
        parent = GameObject.Find("temp").gameObject;
        txtScore = GameObject.Find("score_txt").gameObject;
        txtRecord = GameObject.Find("record_txt").gameObject;
        StartGame();
        StartCoroutine(nameof(Create));
        
    }

    IEnumerator Create()
    {

        while (true)
        {
            if (!CsGlobal.pause)
            {
                if (count < max)
                {
                    Vector2 randomPosition = new Vector2(Random.Range(-1.98f, 1.98f), Random.Range(2.23f, 4.12f));
                    if (checkCloneCoordinates(randomPosition) && checkBallPos(randomPosition))
                    {
                        count++;
                        GameObject clone = Instantiate(template, randomPosition, Quaternion.identity);
                        clone.GetComponent<SpriteRenderer>().material = color[Random.Range(0, 13)];
                        clone.transform.SetParent(parent.transform, true);
                        targetList.Add(clone.gameObject);
                        yield return new WaitForSeconds(1.5f);
                    }
                    else
                        yield return new WaitForSeconds(0f);
                }
                else
                    yield return new WaitForSeconds(2f);
            }
            else
                yield return new WaitForSeconds(0f);
        }
    }


    public static void StartGame()
    {
        
        GameObject ball1 = GameObject.Find("Ball1").gameObject, ball2 = GameObject.Find("Ball2").gameObject;
        max = 3;
        score = 0;
        foreach (Transform child in GameObject.Find("temp").transform)
        {
            targetList.Remove(child.gameObject);
            Destroy(child.gameObject);
        }
        count = 0;
        if (CsGlobal.gameMode == 2)
        {
            ball1.transform.position = new Vector3(-1.9f, 4.09f, 0f);
            ball2.transform.position = new Vector3(1.9f, 4.09f, 0f);
            ball1.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            ball2.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            txtRecord.GetComponent<Text>().text = txtRecord.GetComponent<Text>().text.Split(' ')[0] + " " + PlayerPrefs.GetInt("record2");
        }
        else
        {
            ball1.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            ball1.transform.position = new Vector3(Random.Range(-1.9f, 1.9f), 4.09f, 0f);
            txtRecord.GetComponent<Text>().text = txtRecord.GetComponent<Text>().text.Split(' ')[0] + " " + PlayerPrefs.GetInt("record1");
        }
        txtScore.GetComponent<Text>().text = txtScore.GetComponent<Text>().text.Split(' ')[0] + " " + score;
    }

    public static void AddScore()
    {
        score++;
        txtScore.GetComponent<Text>().text = txtScore.GetComponent<Text>().text.Split(' ')[0] + " " + score;
        if (score % 3 == 0 && max < 9)
        {
            max++;
        }
        count--;
    }

    private bool checkCloneCoordinates(Vector2 randomPosition)
    {
        foreach (GameObject child in targetList)
        {
            Vector2 second = child.transform.position;
            if ((randomPosition - second).magnitude < 0.95f)
            {
                return false;
            }
        }
        return true;
    }

    private bool checkBallPos(Vector2 randomPosition)
    {
        if (CsGlobal.gameMode == 1)
        {
            var ball = GameObject.Find("Ball1").transform;
            var heading = (Vector2)ball.position - randomPosition;
            var distance = heading.magnitude;
            return distance > 3;
        }
        else
        {
            var ball1 = GameObject.Find("Ball1").transform;
            var heading1 = (Vector2)ball1.position - randomPosition;
            var distance1 = heading1.magnitude;

            var ball2 = GameObject.Find("Ball2").transform;
            var heading2 = (Vector2)ball2.position - randomPosition;
            var distance2 = heading2.magnitude;
            return distance1 > 2 && distance2 > 2;
        }
    }
}

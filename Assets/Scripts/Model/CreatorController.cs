using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreatorController : MonoBehaviour
{       
    [SerializeField] private Material[] color = new Material[14];
    
    [SerializeField] private GameObject targetTemplate, targetsParent, ball1, ball2;
   
    [SerializeField] private TextMeshProUGUI txtScore, txtRecord;

    private int currentCount = 0, currentScore = 0, max = 3;

    private List<GameObject> targetList = new List<GameObject>();

    private void Start()
    {
        StartGame();
        StartCoroutine(Create());        
    }

    IEnumerator Create()
    {

        while (true)
        {
            if (!GlobalParams.pause)
            {
                if (currentCount < max)
                {
                    Vector2 randomPosition = new Vector2(Random.Range(-1.98f, 1.98f), Random.Range(2.23f, 4.12f));
                    if (CheckCloneCoordinates(randomPosition) && CheckBallPos(randomPosition))
                    {
                        currentCount++;
                        GameObject clone = Instantiate(targetTemplate, randomPosition, Quaternion.identity);
                        clone.GetComponent<SpriteRenderer>().material = color[Random.Range(0, 13)];
                        clone.transform.SetParent(targetsParent.transform, true);
                        targetList.Add(clone.gameObject);
                        yield return new WaitForSecondsRealtime(1.5f);
                    }
                    else
                        yield return null;
                }
                else
                    yield return new WaitForSecondsRealtime(2f);
            }
            else
                yield return null;
        }
    }


    public void StartGame()
    {
        max = 3;
        currentScore = 0;
        foreach (Transform child in targetsParent.transform)
        {
            targetList.Remove(child.gameObject);
            Destroy(child.gameObject);
        }
        currentCount = 0;
        if (GlobalParams.gameMode == 2)
        {
            ball1.transform.position = new Vector3(-1.9f, 4.09f, 0f);
            ball2.transform.position = new Vector3(1.9f, 4.09f, 0f);
            ball1.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            ball2.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            txtRecord.GetComponent<TextMeshProUGUI>().text = txtRecord.GetComponent<TextMeshProUGUI>().text.Split(' ')[0] + " " + PlayerPrefs.GetInt("record2");
        }
        else
        {
            ball1.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            ball1.transform.position = new Vector3(Random.Range(-1.9f, 1.9f), 4.09f, 0f);
            txtRecord.GetComponent<TextMeshProUGUI>().text = txtRecord.GetComponent<TextMeshProUGUI>().text.Split(' ')[0] + " " + PlayerPrefs.GetInt("record1");
        }
        txtScore.GetComponent<TextMeshProUGUI>().text = txtScore.GetComponent<TextMeshProUGUI>().text.Split(' ')[0] + " " + currentScore;
    }

    public void AddScore()
    {
        currentScore++;
        txtScore.GetComponent<TextMeshProUGUI>().text = txtScore.GetComponent<TextMeshProUGUI>().text.Split(' ')[0] + " " + currentScore;
        if (currentScore % 3 == 0 && max < 9)
        {
            max++;
        }
        currentCount--;
    }

    private bool CheckCloneCoordinates(Vector2 randomPosition)
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

    private bool CheckBallPos(Vector2 randomPosition)
    {
        if (GlobalParams.gameMode == 1)
        {
            var ball = ball1.transform;
            var heading = (Vector2)ball.position - randomPosition;
            var distance = heading.magnitude;
            return distance > 3;
        }
        else
        {
            var _ball1 = ball1.transform;
            var heading1 = (Vector2)_ball1.position - randomPosition;
            var distance1 = heading1.magnitude;

            var _ball2 = ball2.transform;
            var heading2 = (Vector2)_ball2.position - randomPosition;
            var distance2 = heading2.magnitude;
            return distance1 > 2 && distance2 > 2;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Класс реализовывающий управелние игровой моделью и визуальной часть
/// </summary>
public class GameModel : MonoBehaviour
{
    /// <summary>
    /// Доступные цвета для цели
    /// </summary>
    [SerializeField] private Material[] color = new Material[14];

    //Ссылка на игровые объекты
    [SerializeField] private GameObject targetTemplate, targetsParent, ball1, ball2;

    //Ссылка на текстовые объекты
    [SerializeField] private TextMeshProUGUI txtScore, txtRecord;

    //Параметры игры
    private int currentCount = 0, currentScore = 0, maxTargets = 3;

    /// <summary>
    /// Список созданых целей
    /// </summary>
    private List<GameObject> targetList = new List<GameObject>();

    /// <summary>
    /// Границы для создания целей и спавна мяча
    /// </summary>
    private readonly float targetXBorder = 1.98f, targetYBorderMin = 2.23f, targetYBorderMax = 4.12f, ballXPos = 1.9f, ballYPos = 4.09f;

    private void Start()
    {
        StartGame();
        StartCoroutine(Create());
    }

    /// <summary>
    /// Спавнер целей
    /// </summary>
    /// <returns></returns>
    IEnumerator Create()
    {
        while (true)
        {
            if (GlobalParams.pause)
            {
                yield return null;
                continue;
            }

            if (currentCount < maxTargets)
            {
                Vector2 randomPosition = new Vector2(Random.Range(-targetXBorder, targetXBorder), Random.Range(targetYBorderMin, targetYBorderMax));

                if (CheckTargetCoordinates(randomPosition) && CheckBallCoordinates(randomPosition))
                {
                    GameObject target = Instantiate(targetTemplate, randomPosition, Quaternion.identity);
                    target.GetComponent<SpriteRenderer>().material = color[Random.Range(0, 13)];
                    target.transform.SetParent(targetsParent.transform, true);

                    targetList.Add(target);
                    currentCount++;

                    yield return new WaitForSecondsRealtime(1.5f);
                }
                else
                    yield return null;
            }
            else
                yield return new WaitForSecondsRealtime(1.5f);
        }
    }

    /// <summary>
    /// Запуск игры
    /// </summary>
    public void StartGame()
    {
        maxTargets = 3;
        currentScore = 0;
        currentCount = 0;
        targetList.Clear();

        foreach (Transform child in targetsParent.transform)
            Destroy(child.gameObject);

        if (GlobalParams.gameMode == 1)
        {
            ball2.SetActive(false);
            ball1.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            ball1.transform.position = new Vector2(Random.Range(-ballXPos, ballXPos), ballYPos);
            txtRecord.text = $"{txtRecord.text.Split(' ')[0]} {GlobalParams.record1}";
        }
        else
        {
            ball2.SetActive(true);
            ball1.transform.position = new Vector2(-ballXPos, ballYPos);
            ball2.transform.position = new Vector2(ballXPos, ballYPos);
            ball1.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            ball2.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            txtRecord.text = $"{txtRecord.text.Split(' ')[0]} {GlobalParams.record2}";
        }

        txtScore.text = $"{txtScore.text.Split(' ')[0]} {currentScore}";
    }

    /// <summary>
    /// Увеличение счета при уничтожении цели
    /// </summary>
    /// <param name="destroyedTarget"></param>
    public void AddScore(GameObject destroyedTarget)
    {
        currentScore++;
        currentCount--;
        targetList.Remove(destroyedTarget);
        txtScore.text = $"{txtScore.text.Split(' ')[0]} {currentScore}";

        if (currentScore % 3 == 0 && maxTargets < 9)
            maxTargets++;
    }

    /// <summary>
    /// Конец игры (при падении мяча)
    /// </summary>
    public void EndGame()
    {
        ball1.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        ball2.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        if (GlobalParams.gameMode == 1)
        {
            if (currentScore > GlobalParams.record1)
            {
                GlobalParams.record1 = currentScore;
            }
        }
        else
        {
            if (currentScore > GlobalParams.record2)
            {
                GlobalParams.record2 = currentScore;
            }
        }
    }

    /// <summary>
    /// Проверка координат спавна новой цели относительно других целей
    /// </summary>
    /// <param name="newPosition">Коориданты новой цели</param>
    private bool CheckTargetCoordinates(Vector2 newPosition)
    {
        foreach (GameObject target in targetList)
        {
            Vector2 targetPosition = target.transform.position;
            if ((newPosition - targetPosition).magnitude < 0.95f)
                return false;
        }

        return true;
    }

    /// <summary>
    /// Проверка координат спавна новой цели относительно мячей
    /// </summary>
    /// <param name="randomPosition">Коориданты новой цели</param>
    private bool CheckBallCoordinates(Vector2 randomPosition)
    {
        if (GlobalParams.gameMode == 1)
        {
            var _ball1 = ball1.transform;
            var heading = (Vector2)_ball1.position - randomPosition;
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

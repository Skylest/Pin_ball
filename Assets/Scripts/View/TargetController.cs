using UnityEngine;

public class TargetController : MonoBehaviour
{
    /// <summary>
    /// Объект анимации уничтожения
    /// </summary>
    [SerializeField] private GameObject objectAnimDestroy;

    /// <summary>
    /// Музыкальный плеер
    /// </summary>
    [SerializeField] private MusPlayer musPlayer;

    /// <summary>
    /// Вектор скорости вращения
    /// </summary>
    private Vector3 vectorRotate = new Vector3(0, 0, 0.4f);

    void Update()
    {
       transform.Rotate(vectorRotate, Space.Self);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
           /* CreatorController.AddScore(); //TODO
            CreatorController.targetList.Remove(gameObject);*/
            
            GameObject _objectAnimDestroy = Instantiate(objectAnimDestroy);
            gameObject.transform.parent = gameObject.transform;
            gameObject.transform.parent = null;
            _objectAnimDestroy.transform.SetPositionAndRotation(transform.position, transform.rotation);
            

            foreach (Transform child in _objectAnimDestroy.transform)            
                child.gameObject.GetComponent<SpriteRenderer>().material = GetComponent<SpriteRenderer>().material;      

            musPlayer.PlaySoundOnClick();
            Destroy(gameObject);
        }
    }
}

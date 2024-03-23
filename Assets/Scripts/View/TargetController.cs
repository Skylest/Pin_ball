using UnityEngine;

/// <summary>
/// ����� ��������������� ���������� �����
/// </summary>
public class TargetController : MonoBehaviour
{
    /// <summary>
    /// ������ ������ ��� �����������
    /// </summary>
    [SerializeField] private GameObject objectAnimDestroy;

    /// <summary>
    /// ������ �� ���������� ��������
    /// </summary>
    [SerializeField] private GameController gameController;

    /// <summary>
    /// ������ �������� ��������
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
            gameController.OnDestroyTarget(gameObject);

            GameObject _objectAnimDestroy = Instantiate(objectAnimDestroy);
            gameObject.transform.parent = gameObject.transform;
            gameObject.transform.parent = null;
            _objectAnimDestroy.transform.SetPositionAndRotation(transform.position, transform.rotation);
            

            foreach (Transform child in _objectAnimDestroy.transform)            
                child.gameObject.GetComponent<SpriteRenderer>().material = GetComponent<SpriteRenderer>().material;

            MusicPlayer.Instance.PlaySoundOnClick();
            Destroy(gameObject);
        }
    }
}

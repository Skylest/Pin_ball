using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{   
	/// <summary>
	/// Радиус взрыва
	/// </summary>
	[SerializeField] private float radius;
	
	/// <summary>
	/// Сила взрыва
	/// </summary>
	[SerializeField] private float power;

	/// <summary>
	/// Слой к которому применяется взрыв
	/// </summary>
	[SerializeField] private LayerMask layerMask;

    void Start()
    {
        Explosion2D(gameObject.transform.position);
    }

    void Update()
    {
        if (gameObject.transform.childCount == 0)
        {
            Destroy(gameObject);
        }
    }

	/// <summary>
	/// Применение ускорения от взрыва для затронутых объектов
	/// </summary>
	/// <param name="position"></param>
    private void Explosion2D(Vector3 position)
	{
		Collider2D[] colliders = Physics2D.OverlapCircleAll(position, radius, layerMask);

		foreach (Collider2D hit in colliders)
		{
			if (hit.attachedRigidbody != null)
			{
				Vector3 direction = hit.transform.position - position;
				direction.z = 0;
				hit.attachedRigidbody.AddForce(direction.normalized * power);
			}
		}
	}
}

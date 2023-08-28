using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		Explosion2D(gameObject.transform.position);

	}

    // Update is called once per frame
    void Update()
    {
		if (gameObject.transform.childCount == 0)
		{
			Destroy(gameObject);
		}
    }

	[SerializeField] private float radius;
	[SerializeField] private float power;
	[SerializeField] private LayerMask layerMask;

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

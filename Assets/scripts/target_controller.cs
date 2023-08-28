using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target_controller : MonoBehaviour
{
    [SerializeField]
    GameObject Anim, mus;

    private Vector3 vector;  
    // Start is called before the first frame update
    void Start()
    {
        vector = new Vector3(0, 0, 0.4f);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().Rotate(vector, Space.Self);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball1" || collision.gameObject.name == "Ball2")
        {
            creator.AddScore();
            creator.targetList.Remove(this.gameObject);
            GameObject _temp = Instantiate(Anim);
            _temp.SetActive(true);
            _temp.transform.position = transform.position;
            _temp.transform.rotation = transform.rotation;
            foreach (Transform child in _temp.transform)
            {
                child.gameObject.GetComponent<SpriteRenderer>().material = GetComponent<SpriteRenderer>().material;
            }
            mus.GetComponent<AudioSource>().Play();
            Destroy(this.gameObject);
        }
    }
}

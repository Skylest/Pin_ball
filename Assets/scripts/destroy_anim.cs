using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_anim : MonoBehaviour
{
    

    void Start()
    {
        gameObject.transform.parent = null;
        StartCoroutine(nameof(Scale));
    }

    IEnumerator Scale()
    {
        while (true)
        {
            float x = gameObject.transform.localScale.x - 0.003f;
            float y = gameObject.transform.localScale.y - 0.003f;
            gameObject.transform.localScale = new Vector3(x, y, 1);
            if (x <= 0.05 && y <= 0.05)
            {
                Destroy(gameObject);
                break;
            }
            yield return new WaitForEndOfFrame();
        }
    }


}

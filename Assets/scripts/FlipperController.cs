using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlipperController : MonoBehaviour
{

    public HingeJoint2D right, left;
    private Rect leftPart = new Rect(0, 0, Screen.width / 2, Screen.height);
    private Rect rightPart = new Rect(Screen.width / 2, 0, Screen.width, Screen.height);

    private void Start()
    {
        StartCoroutine(nameof(Right));
        StartCoroutine(nameof(Left));
    }


    IEnumerator Left()
    {
        while (true)
        {
            if (!CsGlobal.pause)
            {
                if (checkTouch(leftPart))
                {
                    left.useMotor = true;
                    yield return new WaitForSeconds(0f);
                }
                else
                {
                    left.useMotor = false;
                    yield return new WaitForSeconds(0f);
                }
            }
            else
            {
                left.useMotor = false;
                yield return new WaitForSeconds(0f);
            }
        }
    }

    IEnumerator Right()
    {
        while (true)
        {
            if (!CsGlobal.pause)
            {
                if (checkTouch(rightPart))
                {
                    right.useMotor = true;
                    yield return new WaitForSeconds(0f);
                }
                else
                {
                    right.useMotor = false;
                    yield return new WaitForSeconds(0f);
                }
            }
            else
            {
                right.useMotor = false;
                yield return new WaitForSeconds(0f);
            }
        }
    }

    private bool checkTouch(Rect rect)
    {
        foreach (Touch t in Input.touches)
        {
            if (rect.Contains(t.position))
            {
                return true;
            }
        }
        return false;
    }
}

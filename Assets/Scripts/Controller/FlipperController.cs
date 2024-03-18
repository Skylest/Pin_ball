using UnityEngine;

/// <summary>
/// Класс реализовывающий управление флипперами
/// </summary>
public class FlipperController : MonoBehaviour
{
    /// <summary>
    /// Компоненты управления флипперами
    /// </summary>
    [SerializeField] private HingeJoint2D rightFlipper, leftFlipper;
    
    /// <summary>
    /// Ректангл для обработки левого тапа
    /// </summary>
    private Rect leftPart = new Rect(0, 0, Screen.width / 2, Screen.height);

    /// <summary>
    /// Ректангл для обработки правого тапа
    /// </summary>
    private Rect rightPart = new Rect(Screen.width / 2, 0, Screen.width, Screen.height);
    
    private void Update()
    {
        if (GlobalParams.pause)
            return;

        if (CheckTouch(leftPart))        
            leftFlipper.useMotor = true;
        
        else        
            leftFlipper.useMotor = false;
        

        if (CheckTouch(rightPart))        
            rightFlipper.useMotor = true;
        
        else        
            rightFlipper.useMotor = false;
        
    }
    
    /// <summary>
    /// Проверка на какую часть экрана был клик или тап
    /// </summary>
    /// <param name="rect">Ректангл части экрана</param>
    private bool CheckTouch(Rect rect)
    {
        if (Input.GetMouseButton(0))
        {
            return rect.Contains(Input.mousePosition);
        }

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

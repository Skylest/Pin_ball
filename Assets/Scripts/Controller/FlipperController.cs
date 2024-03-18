using UnityEngine;

/// <summary>
/// ����� ��������������� ���������� ����������
/// </summary>
public class FlipperController : MonoBehaviour
{
    /// <summary>
    /// ���������� ���������� ����������
    /// </summary>
    [SerializeField] private HingeJoint2D rightFlipper, leftFlipper;
    
    /// <summary>
    /// �������� ��� ��������� ������ ����
    /// </summary>
    private Rect leftPart = new Rect(0, 0, Screen.width / 2, Screen.height);

    /// <summary>
    /// �������� ��� ��������� ������� ����
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
    /// �������� �� ����� ����� ������ ��� ���� ��� ���
    /// </summary>
    /// <param name="rect">�������� ����� ������</param>
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

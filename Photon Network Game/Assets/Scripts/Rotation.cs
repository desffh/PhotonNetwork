using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float mouseX;
    [SerializeField] float mouseY;

    [SerializeField] float speed;


    public void RotateX()
    {
        // mouseY�� ���콺�� �Է��� ���� �����մϴ�. "Mouse Y"
        mouseY += Input.GetAxisRaw("Mouse Y") * speed * Time.deltaTime;

        // MouseY�� ���� -65 ~ 65 ������ ������ �����մϴ�.
        mouseY = Mathf.Clamp(mouseY, -65, 65);

        // mouseY <- Mathf.Clamp(�����Ϸ��� ��, �ּҰ�, �ִ밪)

        transform.localEulerAngles = new Vector3(-mouseY, 0, 0);
        
        // local.EulerAngles 
    }

    // Update is called once per frame
    void Update()
    {
    }
}

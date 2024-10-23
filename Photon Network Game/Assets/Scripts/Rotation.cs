using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float mouseX;
    [SerializeField] float mouseY;
    [SerializeField] float speed;

    public void OnKeyUpdate()
    {
        // mouseX에 마우스로 입력한 값을 저장합니다.
        mouseX += Input.GetAxisRaw("Mouse X") * speed * Time.deltaTime;
    }

    public void RotateY(Rigidbody rigidBody)
    {
        rigidBody.transform.eulerAngles = new Vector3(0, mouseX, 0);
    }

    public void RotateX()
    {
        // mouseY에 마우스로 입력한 값을 저장합니다. "Mouse Y"
        mouseY += Input.GetAxisRaw("Mouse Y") * speed * Time.deltaTime;

        // MouseY의 값을 -65 ~ 65 사이의 값으로 제한합니다.
        mouseY = Mathf.Clamp(mouseY, -65, 65);

        // mouseY <- Mathf.Clamp(제한하려는 값, 최소값, 최대값)

        transform.localEulerAngles = new Vector3(-mouseY, 0, 0);
        
        // local.EulerAngles 
    }

    // Update is called once per frame
    void Update()
    {

    }
}

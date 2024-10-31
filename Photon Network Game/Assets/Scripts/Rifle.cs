using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    private Ray ray;
    private RaycastHit raycastHit;

    [SerializeField] Camera camera;
    void Update()
    {
        // ���콺 ���� ��ư
        if(Input.GetMouseButtonDown(0))
        {
            ray = camera.ScreenPointToRay(Input.mousePosition);
            
            if(Physics.Raycast(ray, out raycastHit, Mathf.Infinity))
            {
                Debug.Log(raycastHit.collider.gameObject.name);
            }
        }

    }
}

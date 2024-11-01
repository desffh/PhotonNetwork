using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Rifle : MonoBehaviourPunCallbacks
{
    private Ray ray;
    private RaycastHit raycastHit;

    [SerializeField] LayerMask layerMask;


    [SerializeField] Camera camera;
    void Update()
    {
        // 마우스 왼쪽 버튼
        if(Input.GetMouseButtonDown(0))
        {
            ray = camera.ScreenPointToRay(Input.mousePosition);
            
            if(Physics.Raycast(ray, out raycastHit, Mathf.Infinity, layerMask))
            {
                PhotonView photonView = raycastHit.collider.GetComponent<PhotonView>();
                
                if(photonView.IsMine)
                {
                    photonView.GetComponent<Rack>().Die();

                }
            }

        }

    }
}

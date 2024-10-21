using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class Character : MonoBehaviourPun
{
    [SerializeField] Camera remoteCamera; // 원격개체
    
    // Start is called before the first frame update
    void Start()
    {
        DisableCamera();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableCamera()
    {
        // 현재 플레이어가 나 자신이라면
        if(photonView.IsMine)
        { 
            Camera.main.gameObject.SetActive(false);
        }
        // 자신이 아니라면 remoteCamera 비활성화
        else
        {
            remoteCamera.gameObject.SetActive(false );
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class Character : MonoBehaviourPun
{
    [SerializeField] Camera remoteCamera; // ���ݰ�ü
    
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
        // ���� �÷��̾ �� �ڽ��̶��
        if(photonView.IsMine)
        { 
            Camera.main.gameObject.SetActive(false);
        }
        // �ڽ��� �ƴ϶�� remoteCamera ��Ȱ��ȭ
        else
        {
            remoteCamera.gameObject.SetActive(false );
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(Move))]

public class Character : MonoBehaviourPun
{
    [SerializeField] Move move;
    [SerializeField] Camera remoteCamera; // ���ݰ�ü
    [SerializeField] Rigidbody rigidBody;

    private void Awake()
    {
        move = GetComponent<Move>();
        rigidBody = GetComponent<Rigidbody>();
    }


    // Start is called before the first frame update
    void Start()
    {
        DisableCamera();
    }

    // Update is called once per frame
    void Update()
    {
        move.OnKeyUpdate();   
    }
    
    private void FixedUpdate()
    {
        move.OnMove(rigidBody);
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

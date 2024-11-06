using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using ExitGames.Client.Photon;

[RequireComponent(typeof(Move))]
[RequireComponent (typeof(Rotation))]

public class Character : MonoBehaviourPun
{
    [SerializeField] Move move;
    [SerializeField] Rotation rotation;
    [SerializeField] Camera remoteCamera; // ���ݰ�ü
    [SerializeField] Rigidbody rigidBody;


    private void Awake()
    {

        move = GetComponent<Move>();
        rigidBody = GetComponent<Rigidbody>();
        rotation = GetComponent<Rotation>();
    }


    void Start()
    {
        DisableCamera();
    }

    // Update is called once per frame
    void Update()
    {

        if (photonView.IsMine == false) return;

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            MouseManager.Instance.SetMouse(true);
            PopUpManager.Instance.Show(PopUpType.PAUSE, "Ryu");
        }

        move.OnKeyUpdate();   
        rotation.OnKeyUpdate();
    }
    
    private void FixedUpdate()
    {
        if (photonView.IsMine == false) return;

        move.OnMove(rigidBody);
        rotation.RotateY(rigidBody);
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

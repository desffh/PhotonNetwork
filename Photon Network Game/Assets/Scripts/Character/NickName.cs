using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class NickName : MonoBehaviourPunCallbacks
{
    [SerializeField] Text nickNameText;

    [SerializeField] Camera remoteCamera;

    void Start()
    {
        nickNameText.text = photonView.Owner.NickName;        
    }

    private void Update()
    {
        // �ڽ��̶� local
        
        // ī�޶� �������� �ٶ󺸱�
        transform.LookAt(remoteCamera.transform.localPosition);

        Vector3 euler = transform.localEulerAngles;

        // y�ุ ȸ��
        transform.localRotation = Quaternion.Euler(0, euler.y, 0);
    }

}

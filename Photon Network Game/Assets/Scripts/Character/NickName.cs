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
        // 자식이라 local
        
        // 카메라 시점으로 바라보기
        transform.LookAt(remoteCamera.transform.localPosition);

        Vector3 euler = transform.localEulerAngles;

        // y축만 회전
        transform.localRotation = Quaternion.Euler(0, euler.y, 0);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class Pause : PopUp
{

    public void Exit()
    {
        PhotonNetwork.LeaveRoom(); // 룸을 떠나다    
    }

    // 방을 떠나면 로비로
    public override void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel("Lobby Scene");
    }

    public override void OnConfirm()
    {
        MouseManager.Instance.SetMouse(false);
        gameObject.SetActive(false);
    }
}

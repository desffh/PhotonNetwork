using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using PlayFab.EconomyModels;
using Photon.Realtime;

public class Information : MonoBehaviourPunCallbacks
{
    private string roomName;

    [SerializeField] Text roomTitleText;

    public void OnConnectRoom()
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    public void SetData(string roomName, int currentStaff, int maxStaff)
    {
        this.roomName = roomName;

        roomTitleText.text = roomName + " ( " + currentStaff + " / " + maxStaff + " ) ";
    }

    
}

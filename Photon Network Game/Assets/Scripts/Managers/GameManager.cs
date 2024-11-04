using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class GameManager : MonoBehaviourPunCallbacks
{



    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Execute();
    }

    // 사람이 모일때까지 움직이지 않게
    public void Execute()
    {

        if(PhotonNetwork.CurrentRoom.PlayerCount >= 3)
        {
            Debug.Log("Start");
        }
    }

}

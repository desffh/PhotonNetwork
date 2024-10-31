using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class UnitManager : MonoBehaviourPunCallbacks
{
    private WaitForSeconds waitForSeconds = new WaitForSeconds(5.0f);

    void Start()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            StartCoroutine(Create());

        }
    }

    public IEnumerator Create()
    {
        while (true)
        {
            PhotonNetwork.InstantiateRoomObject("Rack", Vector3.zero, Quaternion.identity);

            yield return waitForSeconds;
        }
    }

    // 마스터가 나가면 0번째 플레이어로 마스터가 바뀜
    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        PhotonNetwork.SetMasterClient(PhotonNetwork.PlayerList[0]);

        if (PhotonNetwork.IsMasterClient)
        {
            StartCoroutine(Create());

        }
    }

}

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

    // �����Ͱ� ������ 0��° �÷��̾�� �����Ͱ� �ٲ�
    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        PhotonNetwork.SetMasterClient(PhotonNetwork.PlayerList[0]);

        if (PhotonNetwork.IsMasterClient)
        {
            StartCoroutine(Create());

        }
    }

}

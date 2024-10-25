using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using WebSocketSharp;

public class NickNameManager : MonoBehaviour
{
    [SerializeField] Button button;

    [SerializeField] InputField inputField;

    [SerializeField] GameObject nickNamePanel; // �˾�â

    // Start is called before the first frame update
    void Start()
    {
        // 1. PhotonNetwork.NickName�� ����� String ���� �ҷ��ɴϴ�. 

        // 2. PhotonNetwork.NickName�� ��� �ִٸ� nickNamePanel�� Ȱ��ȭ�մϴ�.

        PhotonNetwork.NickName = PlayerPrefs.GetString("NickName");

        if(PhotonNetwork.NickName.IsNullOrEmpty())
        {
            nickNamePanel.SetActive(true);
        }
 
    }
    
    public void OnSetNickName()
    {
        // 1. PhotonNetwork.NickName�� inputField�� �Է��� ���� �־��ݴϴ�.

        // 2. NickName�� �����մϴ�.

        // 3. nickNamePanel������Ʈ�� ��Ȱ��ȭ�մϴ�.

        PhotonNetwork.NickName = inputField.text;

        PlayerPrefs.SetString("NickName", PhotonNetwork.NickName);

        nickNamePanel.SetActive(false);
    }
}

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

    [SerializeField] GameObject nickNamePanel; // 팝업창

    // Start is called before the first frame update
    void Start()
    {
        // 1. PhotonNetwork.NickName에 저장된 String 값을 불러옵니다. 

        // 2. PhotonNetwork.NickName이 비어 있다면 nickNamePanel을 활성화합니다.

        PhotonNetwork.NickName = PlayerPrefs.GetString("NickName");

        if(PhotonNetwork.NickName.IsNullOrEmpty())
        {
            nickNamePanel.SetActive(true);
        }
 
    }
    
    public void OnSetNickName()
    {
        // 1. PhotonNetwork.NickName에 inputField로 입력한 값을 넣어줍니다.

        // 2. NickName을 저장합니다.

        // 3. nickNamePanel오브젝트를 비활성화합니다.

        PhotonNetwork.NickName = inputField.text;

        PlayerPrefs.SetString("NickName", PhotonNetwork.NickName);

        nickNamePanel.SetActive(false);
    }
}

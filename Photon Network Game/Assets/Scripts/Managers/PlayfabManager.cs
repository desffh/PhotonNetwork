using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class PlayfabManager : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField emailInputField;
    [SerializeField] InputField passwordInputField;

    // 로그인이 성공했을 때
    public void Success(LoginResult loginResult)
    {
        PhotonNetwork.AutomaticallySyncScene = false;

        PhotonNetwork.GameVersion = "1.0f";

        PhotonNetwork.LoadLevel("Lobby Scene");
    }


    // 회원가입이 실패했을 때
    public void Failure(PlayFabError playFabError)
    {
        PopUpManager.Instance.Show(PopUpType.TEXT, playFabError.GenerateErrorReport());
    }
    
    // 로그인
    public void OnSignIn()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailInputField.text,
            Password = passwordInputField.text,
        };

        PlayFabClientAPI.LoginWithEmailAddress
        (
            request,
            Success,
            Failure
        );
    }
    public void OnSignUp()
    {
        PopUpManager.Instance.Show(PopUpType.SIGNUP, "Kim");

    }   

}

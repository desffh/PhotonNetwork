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

    // �α����� �������� ��
    public void Success(LoginResult loginResult)
    {
        PhotonNetwork.AutomaticallySyncScene = false;

        PhotonNetwork.GameVersion = "1.0f";

        PhotonNetwork.LoadLevel("Lobby Scene");
    }

    // ȸ�������� �������� ��
    public void Success(RegisterPlayFabUserResult registerPlayFabUserResult)
    {
        Debug.Log(registerPlayFabUserResult.Request);
        Debug.Log(registerPlayFabUserResult.ToString());
    }
    // ȸ�������� �������� ��
    public void Failure(PlayFabError playFabError)
    {
        Debug.Log(playFabError.GenerateErrorReport());
    }
    
    // �α���
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
        var request = new RegisterPlayFabUserRequest
        {
            Email = emailInputField.text,
            Password = passwordInputField.text,
            RequireBothUsernameAndEmail = false
        };

        PlayFabClientAPI.RegisterPlayFabUser
        (
            request,
            Success,
            Failure
        );
    }   

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using Photon.Pun;
using Unity.VisualScripting;

public class SignUp : PopUp
{
    [SerializeField] InputField emailInputField;
    [SerializeField] InputField passwordInputField;
    [SerializeField] InputField nicknameInputField;
    // ȸ�������� �������� ��
    public void Success(RegisterPlayFabUserResult registerPlayFabUserResult)
    {
        Debug.Log(registerPlayFabUserResult.Request);
        Debug.Log(registerPlayFabUserResult.ToString());
    }

    // ȸ�������� �������� ��
    public void Failure(PlayFabError playFabError)
    {
        PopUpManager.Instance.Show(PopUpType.TEXT, playFabError.GenerateErrorReport());
    }
    public override void OnConfirm()
    {
        // ȸ������
        var request = new RegisterPlayFabUserRequest
        {
            Email = emailInputField.text,
            Password = passwordInputField.text,
            Username = nicknameInputField.text,
        };

        PlayFabClientAPI.RegisterPlayFabUser
        (
            request,
            Success,
            Failure
        );

        PhotonNetwork.NickName = nicknameInputField.text;

        PlayerPrefs.SetString("Nickname",PhotonNetwork.NickName);

        emailInputField.text = "";
        passwordInputField.text = "";
        nicknameInputField.text = "";

        gameObject.SetActive(false );
    }
}

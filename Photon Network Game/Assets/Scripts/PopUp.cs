using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PopUp : MonoBehaviour
{
    [SerializeField] Text text;
    
    public void SetData(string message)
    {
        text.text = message;
    }


    // �ݾ��ֱ� ��ư
    public void OnClose()
    {
        gameObject.SetActive(false);
    }






}

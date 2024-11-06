using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Alram : PopUp
{
    [SerializeField] Text content;
    public override void OnConfirm()
    {
        // text만 나오는 창
        gameObject.SetActive(false);

    }
}

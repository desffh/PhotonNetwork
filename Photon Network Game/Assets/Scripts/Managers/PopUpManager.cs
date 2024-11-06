using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

// 열거형
public enum PopUpType
{
    TEXT,
    SIGNUP,
    PAUSE
}

public class PopUpManager : MonoBehaviour
{
    // 딕셔너리
    private Dictionary<PopUpType, GameObject> dictionary
        = new Dictionary<PopUpType, GameObject>(); // 동적할당

    // 싱글톤
    private static PopUpManager instance;

    [SerializeField] Transform parentTransform; // 부모위치

    public static PopUpManager Instance { get { return instance; } }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    public void Show(PopUpType popuptype, string content)
    {
        GameObject popup = null;

        // 키값이 존재한다면
        if (dictionary.TryGetValue(popuptype, out popup))
        {
            popup.SetActive(true);
        }
        else
        {
           // 게임 오브젝트 생성
            popup = Instantiate(Resources.Load<GameObject>(popuptype.ToString()));

            // 게임 오브젝트 부모위치 설정
            popup.transform.SetParent(parentTransform);

            popup.GetComponent<RectTransform>().localPosition = new Vector2(0, 0);

           // PopUp컴포넌트 가져와서 SetData함수 호출
           // popup.GetComponent<PopUp>().SetData(content);

           // 키값이 없다면 딕셔너리에 추가
            dictionary.Add(popuptype, popup);
        }
    }
   
}

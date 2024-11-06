using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

// ������
public enum PopUpType
{
    TEXT,
    SIGNUP,
    PAUSE
}

public class PopUpManager : MonoBehaviour
{
    // ��ųʸ�
    private Dictionary<PopUpType, GameObject> dictionary
        = new Dictionary<PopUpType, GameObject>(); // �����Ҵ�

    // �̱���
    private static PopUpManager instance;

    [SerializeField] Transform parentTransform; // �θ���ġ

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

        // Ű���� �����Ѵٸ�
        if (dictionary.TryGetValue(popuptype, out popup))
        {
            popup.SetActive(true);
        }
        else
        {
           // ���� ������Ʈ ����
            popup = Instantiate(Resources.Load<GameObject>(popuptype.ToString()));

            // ���� ������Ʈ �θ���ġ ����
            popup.transform.SetParent(parentTransform);

            popup.GetComponent<RectTransform>().localPosition = new Vector2(0, 0);

           // PopUp������Ʈ �����ͼ� SetData�Լ� ȣ��
           // popup.GetComponent<PopUp>().SetData(content);

           // Ű���� ���ٸ� ��ųʸ��� �߰�
            dictionary.Add(popuptype, popup);
        }
    }
   
}

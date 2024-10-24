using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class RoomManager : MonoBehaviourPunCallbacks
{
    // content�� �ڽ����� ������
    [SerializeField] Transform parentTransform;
    [SerializeField] InputField roomNameInputField;
    [SerializeField] InputField roomCapacityInputField;

    private Dictionary<string, GameObject> dictionary = new Dictionary<string, GameObject>();

    // �� �Ѿ��
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game Scene");
    }

    // �游���
    public void OnCreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();

        roomOptions.MaxPlayers = byte.Parse(roomCapacityInputField.text);

        roomOptions.IsOpen = true;

        roomOptions.IsVisible = true;

        PhotonNetwork.CreateRoom(roomNameInputField.text, roomOptions);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        GameObject roomPrefab;

        foreach (RoomInfo room in roomList)
        {
            // ���� ������ ���
            if(room.RemovedFromList == true)
            {
                dictionary.TryGetValue(room.Name, out roomPrefab);

                Destroy(roomPrefab); // ���� ������Ʈ �ı�

                dictionary.Remove(room.Name);
            }
            else // ���� ������ ����� ���
            {
                // ���� ó�� ������ ���
                if(dictionary.ContainsKey(room.Name) == false)
                {
                    GameObject roomObject = InstantiateRoom();

                    roomObject.GetComponent<Information>().SetData
                    (
                        room.Name,
                        room.PlayerCount,
                        room.MaxPlayers
                    );

                    dictionary.Add(room.Name, roomObject );
                }
                // ���� ������ ����� ���
                else
                {
                    dictionary.TryGetValue(room.Name , out roomPrefab);

                    roomPrefab.GetComponent<Information>().SetData
                    (
                        room.Name,
                        room.PlayerCount,
                        room.MaxPlayers
                    );
                }
            }
        }


        
    }

    // �� ����
    public GameObject InstantiateRoom()
    {
        // 1. Room ������Ʈ�� �����մϴ�.

        GameObject room = Instantiate(Resources.Load<GameObject>("Room"));

        // 2. Room ������Ʈ�� �θ� ��ġ�� �����մϴ�.

        room.transform.SetParent(parentTransform);

        // 3. Room ������Ʈ�� ��ȯ�մϴ�.
        return room;
    }
}

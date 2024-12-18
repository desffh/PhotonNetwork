using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class RoomManager : MonoBehaviourPunCallbacks
{
    // content의 자식으로 들어가야함
    [SerializeField] Transform parentTransform;
    [SerializeField] InputField roomNameInputField;
    [SerializeField] InputField roomCapacityInputField;

    private Dictionary<string, GameObject> dictionary = new Dictionary<string, GameObject>();

    // 씬 넘어가기
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game Scene");
    }

    // 방만들기
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
            // 룸이 삭제된 경우
            if(room.RemovedFromList == true)
            {
                dictionary.TryGetValue(room.Name, out roomPrefab);

                Destroy(roomPrefab); // 게임 오브젝트 파괴

                dictionary.Remove(room.Name);
            }
            else // 룸의 정보가 변경된 경우
            {
                // 룸이 처음 생성된 경우
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
                // 룸의 정보가 변경된 경우
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

    // 방 생성
    public GameObject InstantiateRoom()
    {
        // 1. Room 오브젝트를 생성합니다.

        GameObject room = Instantiate(Resources.Load<GameObject>("Room"));

        // 2. Room 오브젝트의 부모 위치를 설정합니다.

        room.transform.SetParent(parentTransform);

        // 3. Room 오브젝트를 반환합니다.
        return room;
    }
}

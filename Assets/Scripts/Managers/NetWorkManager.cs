using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using Unity.Mathematics;
using UnityEngine;

public class NetWorkManager : MonoBehaviourPunCallbacks
{
    private readonly string _version = "1.0f";
    private static NetWorkManager _instance;
    
    public static NetWorkManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = GameObject.Find(typeof(NetWorkManager).ToString());
                if (go == null)
                {
                    go = new GameObject(typeof(NetWorkManager).ToString());
                    _instance = go.AddComponent<NetWorkManager>();
                }
                else
                {
                    _instance = go.GetComponent<NetWorkManager>();
                }
            }

            return _instance;
        }
    }
    
    private void Awake()
    {
        GameObject parentGo = GameObject.Find("Managers");
        if (parentGo == null)
        {
            parentGo = new GameObject("Managers");
            gameObject.transform.parent = parentGo.transform;
            DontDestroyOnLoad(parentGo);
        }
        else
        {
            gameObject.transform.parent = parentGo.transform;
        }
    }

    public void Connect()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = _version;
        PhotonNetwork.ConnectUsingSettings();
    }

    public bool ConnectedCheck()
    {
        return PhotonNetwork.IsConnected;
        
    }

    public void CreateRoom()
    {
        var roomData = RoomManager.Instance.RoomData;
        PhotonNetwork.JoinOrCreateRoom(roomData.roomTitle, new RoomOptions() { MaxPlayers = (byte)roomData.maxPlayer }, null);
    }
    
    // 포톤 서버 연결시 실행
    public override void OnConnectedToMaster()
    {
        print("접속성공.");
        PhotonNetwork.JoinLobby();
    }
    
    // 로비 입장시 실행
    public override void OnJoinedLobby()
    {
        print($"로비입장.");
    }

    public override void OnCreatedRoom()
    {
        print("방 만들기 완료.");
    }
    
    public override void OnJoinedRoom()
    {
        print("방 참가 완료.");
    }
    
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        print("방 만들기 실패.");
    }
    
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        print("방 참가 실패.");
    }
    
    public override void OnDisconnected(DisconnectCause cause)
    {
        print("연결 끊김.");
    }

    public override void OnLeftRoom()
    {
        Debug.Log("방 나감");
    }
    
    
}

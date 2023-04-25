using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class NetWorkManager : MonoBehaviourPunCallbacks
{
    private readonly string _version = "1.0f";
    private static NetWorkManager _instance;

    private void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = _version;
        Connect();
    }

    public void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    
    // 포톤 서버 연결시 실행
    public override void OnConnectedToMaster()
    {
        print("접속성공.");
        PhotonNetwork.JoinOrCreateRoom("Loby", new RoomOptions() { MaxPlayers = 10 }, null);
    }

    // 로비 입장시 실행
    public override void OnJoinedLobby()
    {
        print($"로비입장.");
    }

    public override void OnCreatedRoom()
    {
        print("방 만들기 완료.");
        Debug.Log(PhotonNetwork.CurrentRoom.Name);
    }
    
    public override void OnJoinedRoom()
    {
        print("방 참가 완료.");
        Debug.Log(PhotonNetwork.CurrentRoom.Name);
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

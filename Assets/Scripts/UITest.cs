using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;

enum asd
{
    lobby,
    room,
    join,
}

public class UITest : ConnectManager
{
    public Button btnIn;
    public Button btnOut;
    public Button btnJoin;
    private asd asdf;

    private void Start()
    {
        Connect();
        SettingBtn();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log($"연결성공");

        switch (asdf)
        {
            case asd.lobby :
                PhotonNetwork.JoinLobby();
                break;
            case asd.room :
                PhotonNetwork.JoinOrCreateRoom("TestRoom", new RoomOptions() { MaxPlayers = 5 }, null);
                break;
            case asd.join :
                PhotonNetwork.JoinRoom("TestRoom");
                break;
        }
    }

    void SettingBtn()
    {
        btnIn.onClick.AddListener(() =>
        {
            PhotonNetwork.Disconnect();
            asdf = asd.room;
            Connect();
        });
        
        btnOut.onClick.AddListener(() =>
        {
            PhotonNetwork.Disconnect();
            asdf = asd.lobby;
            Connect();
        });
        
        btnJoin.onClick.AddListener((() =>
        {
            PhotonNetwork.Disconnect();
            asdf = asd.join;
            Connect();
        }));
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        Debug.Log("이건 뭔데!!");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log($"{roomList.Count} 개의 방이 있다");
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("로비에 입장!!");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log($"{PhotonNetwork.CurrentRoom.Name} 방에 입장!!");
        
    }

    public override void OnLeftLobby()
    {
        PhotonNetwork.Disconnect();
        Debug.Log($"방 퇴장!!");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("");
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        PhotonNetwork.Disconnect();
        Debug.Log($"{otherPlayer.NickName} 님이 퇴장!!");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
    }
}

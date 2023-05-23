using System;
using Photon.Pun;
using Photon.Realtime;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class RoomNetworkController : MonoBehaviourPunCallbacks
{   
    private RoomData _roomData;

    private void Awake()
    {
        CreateOrJoinRoom();
    }
    
    public void CreateOrJoinRoom()
    {
        var roomData = RoomManager.Instance.RoomData;
        PhotonNetwork.JoinOrCreateRoom(roomData.roomTitle, new RoomOptions() { MaxPlayers = (byte)roomData.maxPlayer }, null);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.NickName = PlayerDataManager.Instance.MyNicName;
        
        PhotonNetwork.Instantiate("Prefabs/Player", new Vector3(), quaternion.identity);
        if (photonView.IsMine)
        {
            PhotonNetwork.Instantiate("Prefabs/UI/UIRoom", new Vector3(), quaternion.identity);
        }
    }
}

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
        PhotonNetwork.NickName = PlayerDataManager.Instance.MyNicName;
        PhotonNetwork.CurrentRoom.IsOpen = true;

        PhotonNetwork.Instantiate("Prefabs/Player", new Vector3(), quaternion.identity);
        if (photonView.IsMine)
        {
            PhotonNetwork.Instantiate("Prefabs/UI/UIRoom", new Vector3(), quaternion.identity);
        }
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("방에 입장 >>> 컨트롤러");
    }
}

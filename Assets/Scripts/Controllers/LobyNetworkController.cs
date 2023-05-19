using Photon.Pun;
using Photon.Realtime;
using Unity.Mathematics;
using UnityEngine;

public class LobyNetworkController : ConnectBase
{
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }
    
    public override void OnJoinedLobby()
    {
        Debug.Log("로비입장.");
    }

    public override void OnJoinedRoom()
    {
        
    }
    
    
}

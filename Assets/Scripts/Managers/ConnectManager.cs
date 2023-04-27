using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class ConnectManager : MonoBehaviourPunCallbacks
{
    private readonly string _version = "1.0";
    
    public void Connect()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = _version;
        PhotonNetwork.ConnectUsingSettings();
    }

    public void Disconnecting() => PhotonNetwork.Disconnect();
}

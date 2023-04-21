using System;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class PhotonManager : MonoBehaviourPun
{
    private static PhotonManager _instance;

    public static PhotonManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = GameObject.Find(typeof(PhotonManager).Name);
                if (go == null)
                {
                    go = new GameObject(typeof(PhotonManager).Name);
                    _instance = go.AddComponent<PhotonManager>();
                }
                else
                {
                    _instance = go.GetComponent<PhotonManager>();
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

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public void CreateRoom(RoomData roomData)
    {
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = (byte)roomData.maxPlayer;
        options.IsVisible = true;
        PhotonNetwork.CreateRoom(roomData.roomTitle, options, TypedLobby.Default);
    }
}

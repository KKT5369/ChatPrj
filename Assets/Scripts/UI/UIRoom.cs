using System;
using System.Collections.Generic;
using Class;
using Photon.Pun;
using Photon.Pun.Demo.Hub;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIRoom : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_Text roomTitle;
    [SerializeField] private TMP_Text nicName;
    [SerializeField] private RectTransform chatRect;
    [SerializeField] private GameObject chatItem;
    [SerializeField] private TMP_InputField inputTxt;
    [SerializeField] private Button btnExti;
    
    public void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    
    // 포톤 서버 연결시 실행
    public override void OnConnectedToMaster()
    {
        print("접속성공.");
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions() { MaxPlayers = 10 }, null);
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("로비입장...");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("방입장...");
        Debug.Log($"{PhotonNetwork.CurrentRoom.Name}");
    }

    private void Start()
    {
        btnExti.onClick.AddListener((() => {
        {
            PhotonNetwork.Disconnect();
            SceneLoadManager.Instance.LoadScene(new LobyScene());
        }}));
        SettingRoom();
        Connect();
    }

    void SettingRoom()
    {
        //nicName.text = PhotonNetwork.NickName;
        //roomTitle.text = PhotonNetwork.CurrentRoom.Name;
        //Debug.Log(PhotonNetwork.CurrentRoom.Name);
    }
    
    
}

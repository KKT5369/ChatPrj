using System;
using Class;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIRoom : ConnectManager
{
    [SerializeField] private TMP_Text roomTitle;
    [SerializeField] private TMP_Text nicName;
    [SerializeField] private RectTransform chatRect;
    [SerializeField] private TMP_Text chatItem;
    [SerializeField] private TMP_InputField inputTxt;
    [SerializeField] private Button btnExti;

    private PhotonView pv;
    private RoomData _roomData;

    // 포톤 서버 연결시 실행
    public override void OnConnectedToMaster()
    {
        _roomData = RoomManager.Instance.RoomData;
        print($"접속성공.");
        
        PhotonNetwork.JoinOrCreateRoom(_roomData.roomTitle, new RoomOptions() { MaxPlayers = (byte)_roomData.maxPlayer }, null);
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("로비...");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("방입장...");
        PhotonNetwork.NickName = PlayerDataManager.Instance.MyNicName;
        PhotonNetwork.CurrentRoom.IsOpen = true;
        SettingRoom();
    }
    
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("방 입장 실패...");
        Debug.Log($"Message >>> {message}");
        if (message.Equals("Game full"))
        {
            Disconnecting();
            PopupManager.Instance.CreatePopup(new PopupData("입장불가","풀방이네요"),(() => {SceneLoadManager.Instance.LoadScene(new LobyScene());}));
        }
    }

    public override void OnLeftRoom()
    {
        Debug.Log($"{PlayerDataManager.Instance.MyNicName} 님이 {PhotonNetwork.CurrentRoom.Name} 을 떠나감");
    }

    private void Start()
    {
        Connect();
        
        btnExti.onClick.AddListener((() => {
        {
            Disconnecting();
            SceneLoadManager.Instance.LoadScene(new LobyScene());
        }}));
        
        inputTxt.onEndEdit.AddListener(delegate { Send(); });
    }

    void SettingRoom()
    {
        pv = GetComponent<PhotonView>();
        nicName.text = PhotonNetwork.NickName;
        roomTitle.text = PhotonNetwork.CurrentRoom.Name;
    }

    public void Send()
    {
        string chat = $"{nicName.text} : {inputTxt.text}";
        pv.RPC(nameof(ChatRPC),RpcTarget.All,chat);
        chatItem.text = "";
    }
    
    [PunRPC]
    void ChatRPC(string msg)
    {
        chatItem.text = msg;
        var item = Instantiate(chatItem.gameObject, chatRect);
        item.SetActive(true);
    }
    
    
    
    
}

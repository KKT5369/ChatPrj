using Class;
using DG.Tweening;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIRoom : ConnectManager
{
    [SerializeField] private TMP_Text roomTitle;
    [SerializeField] private TMP_Text nicName;
    [SerializeField] private TMP_Text txtSystemMsg;
    [SerializeField] private RectTransform chatRect;
    [SerializeField] private TMP_Text chatItem;
    [SerializeField] private TMP_InputField inputTxt;
    [SerializeField] private Button btnExti;
    

    public PhotonView pv;
    private RoomData _roomData;
    
    private void Start()
    {
        Debug.Log("Start 실행...");
        Connect();
        btnExti.onClick.AddListener((() => {
        {
            Disconnecting();
            SceneLoadManager.Instance.LoadScene(SceneType.LobyScene);
        }}));
        
        inputTxt.onEndEdit.AddListener(delegate
        {
            if(inputTxt.text.Equals("")) return;
            Send();
        });
    }

    #region 포톤 콜백 함수
    
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
        Debug.Log(PhotonNetwork.IsMasterClient);
        Debug.Log(photonView.ViewID);
        PhotonNetwork.NickName = PlayerDataManager.Instance.MyNicName;
        PhotonNetwork.CurrentRoom.IsOpen = true;
        SettingRoom();
        pv.RPC(nameof(SystemMsgPopup),RpcTarget.All,PhotonNetwork.NickName);
    }
    
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        if (message.Equals("Game full"))
        {
            Disconnecting();
            PopupManager.Instance.CreatePopup(new PopupData("입장불가","삐빅! 정.원.초.과"),(() => {SceneLoadManager.Instance.LoadScene(SceneType.LobyScene);}));
        }
    }

    public override void OnLeftRoom()
    {
        Debug.Log($"{PlayerDataManager.Instance.MyNicName} 님이 {PhotonNetwork.CurrentRoom.Name} 을 떠나감");
    }
    

    #endregion
    
    

    void SettingRoom()
    {
        nicName.text = PhotonNetwork.NickName;
        roomTitle.text = PhotonNetwork.CurrentRoom.Name;
    }

    public void Send()
    {
        string chat = $"{nicName.text} : {inputTxt.text}";
        pv.RPC(nameof(ChatRPC),RpcTarget.All,chat);
        inputTxt.text = "";
    }
    
    [PunRPC]
    void ChatRPC(string msg)
    {
        chatItem.text = msg;
        var item = Instantiate(chatItem.gameObject, chatRect);
        item.SetActive(true);
    }
    
    [PunRPC]
    public void SystemMsgPopup(string nicName)
    {
        txtSystemMsg.text = $"{nicName} 님이 두두둥장!!";
        txtSystemMsg.DOFade(0f, 3f);
    }
    
    
}

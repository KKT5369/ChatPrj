using Class;
using Photon.Pun;
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

    private RoomData _roomData;
    
    public void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    
    // 포톤 서버 연결시 실행
    public override void OnConnectedToMaster()
    {
        _roomData = RoomManager.Instance.RoomDatas;
        print("접속성공.");
        
        PhotonNetwork.JoinOrCreateRoom(_roomData.roomTitle, new RoomOptions() { MaxPlayers = 10 }, null);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("방입장...");
        PhotonNetwork.NickName = _roomData.HostName;
        PhotonNetwork.CurrentRoom.MaxPlayers = (byte)_roomData.maxPlayer;
        PhotonNetwork.CurrentRoom.IsOpen = true;
        SettingRoom();
    }

    private void Start()
    {
        Connect();
        
        btnExti.onClick.AddListener((() => {
        {
            PhotonNetwork.Disconnect();
            SceneLoadManager.Instance.LoadScene(new LobyScene());
        }}));
    }

    void SettingRoom()
    {
        nicName.text = PhotonNetwork.NickName;
        roomTitle.text = PhotonNetwork.CurrentRoom.Name;
    }
    
    
}

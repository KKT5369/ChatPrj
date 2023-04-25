using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UILoby : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_Text txtMyNicName;
    [SerializeField] private RectTransform content;
    [SerializeField] private GameObject roomInfo;
    
    [Header("TOP Buttns")] 
    [SerializeField] private Button btnNicNameModify;
    [SerializeField] private Button btnExit;
    [SerializeField] private Button btnUserInfo;
    [SerializeField] private Button btnShop;
    
    [Header("Room Buttons")]
    [SerializeField] private Button btnCreateRoom;
    [SerializeField] private Button btnJoinRoom;
    [SerializeField] private Button btnRoomRefresh;
    [SerializeField] private Button btnPrePage;
    [SerializeField] private Button btnNextPage;

    private List<GameObject> _roomList = new ();
    
    public void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    
    // 포톤 서버 연결시 실행
    public override void OnConnectedToMaster()
    {
        print("접속성공.");
        PhotonNetwork.JoinLobby();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (var v in _roomList)
        {
            Destroy(v);
        }
        _roomList.Clear();
        Debug.Log($"{roomList.Count}");
        foreach (var v in roomList)
        {
            var roomData = new RoomData();
            roomData.roomTitle = v.Name;
            roomData.maxPlayer = v.MaxPlayers;
            roomData.roomNum = 1;
            roomData.HostName = "몰라";
            
            var go = Instantiate(roomInfo, content);
            go.SetActive(true);
            go.GetComponent<RoomItem>().SetValue(roomData);
            _roomList.Add(go);
        }
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("로비입장...");
    }

    private void Awake()
    {
        SetAddlistener();
        Connect();
        RoomManager.Instance.createLobyRoom = SetingRoom;
    }

    private void Start()
    {
        if (!PlayerPrefs.GetString("MyNicName").Equals(""))
        {
            PlayerDataManager.Instance.MyNicName = PlayerPrefs.GetString("MyNicName");
            txtMyNicName.text = PlayerDataManager.Instance.MyNicName;
        }
        else
        {
            UIManager.Instance.CreateUI<UIInputPopup>();
        }
    }

    public void SetUserName()
    {
        txtMyNicName.text = PlayerDataManager.Instance.MyNicName;
    }

    public void SetingRoom(RoomData roomData)
    {
        var go = Instantiate(roomInfo, content);
        go.SetActive(true);
        go.GetComponent<RoomItem>().SetValue(roomData);
        _roomList.Add(go);
    }

    public void Refresh()
    {
        foreach (var v in _roomList)
        {
            Destroy(v);
        }
        _roomList.Clear();
        
    }

    void SetAddlistener() 
    {
        btnNicNameModify.onClick.AddListener((() => InputPopupManager.Instance.CreatePopup<UIInputPopup>(PopupType.ModifyNicName)));
        btnExit.onClick.AddListener((() => Debug.Log("종료")));
        
        btnCreateRoom.onClick.AddListener((() => UIManager.Instance.CreateUI<UICreateRoom>()));
        btnRoomRefresh.onClick.AddListener(Refresh);
    }
}

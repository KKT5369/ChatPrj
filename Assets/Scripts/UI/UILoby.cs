using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
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
    [SerializeField] private Button btnRandomRoom;
    [SerializeField] private Button btnRoomRefresh;
    [SerializeField] private Button btnPrePage;
    [SerializeField] private Button btnNextPage;

    private List<GameObject> _roomList = new ();
    public PhotonView pv;

    private void Awake()
    {
        SetAddlistener();
    }
    
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log("룸 업데이트 <<< ");
        int roomNum = 0;
        foreach (var v in _roomList)
        {
            Destroy(v);
        }
        _roomList.Clear();
        foreach (var v in roomList)
        {
            if (v.MaxPlayers == 0)
                continue;
            var roomData = new RoomData();
            roomData.roomTitle = v.Name;
            roomData.purPlayerNum = v.PlayerCount;
            roomData.maxPlayer = v.MaxPlayers;
            roomData.roomNum = ++roomNum;

            var go = Instantiate(roomInfo, content);
            go.SetActive(true);
            go.GetComponent<RoomItem>().SetValue(roomData);
            _roomList.Add(go);
        }
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

    void SetAddlistener() 
    {
        btnNicNameModify.onClick.AddListener((() => InputPopupManager.Instance.CreatePopup<UIInputPopup>(PopupType.ModifyNicName)));
        btnExit.onClick.AddListener((() => Application.Quit()));
        btnRandomRoom.onClick.AddListener((() => SceneLoadManager.Instance.LoadScene<RoomScene>()));
        btnCreateRoom.onClick.AddListener((() => UIManager.Instance.CreateUI<UICreateRoom>()));
        
    }
}

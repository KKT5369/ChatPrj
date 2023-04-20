using System;
using Class;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UICreateRoom : MonoBehaviour
{
    [Header("Value")]
    [SerializeField] private TMP_InputField inputRoomTitle;
    [SerializeField] private TMP_Dropdown roomOption;
    [SerializeField] private TMP_Dropdown userNumberValue;
    
    [SerializeField] private Button btnOkey;
    [SerializeField] private Button btncancel;

    private void Awake()
    {
        SetAddListener();
    }

    private void CreateRoom()
    {
        RoomData roomData = new RoomData();
        roomData.roomNum = RoomManager.instance.GetEmptyRoom();
        if (inputRoomTitle.text.Equals(""))
        {
            PopupData popupData = new PopupData("경고","방 이름을 설정 하세요");
            PopupManager.instance.CreatePopup(popupData);
            return;
        }
        if (roomData.roomNum == -1)
        {
            PopupData popupData = new PopupData("생성 불가","더이상 새로운 방을 생성 할수 없습니다.");
            PopupManager.instance.CreatePopup(popupData);
            return;
        }
        roomData.HostName = PlayerDataManager.instance.MyNicName;
        roomData.roomTitle = inputRoomTitle.text;
        GameType? gameType = GetGameType();
        if (gameType == null)
        {
            Debug.Log("선택된 게임이 없습니다.");
            return;
        }
        roomData.gameType = gameType;
        roomData.userNumber = userNumberValue.value + 1;
        
        RoomManager.instance.CreateRoom(roomData);
        SceneLoadManager.instance.LoadScene(new RoomScene());
        UIManager.instance.CloseUI(gameObject);
    }

    private GameType? GetGameType()
    {
        switch (roomOption.value)
        {
            case 0 :
                return GameType.Game1;
            case 1 :
                return GameType.Game2;
            case 2 :
                return GameType.Game3;
        }

        return null;
    }


    void SetAddListener()
    {
        btnOkey.onClick.AddListener(CreateRoom);
        btncancel.onClick.AddListener((() => UIManager.instance.CloseUI(gameObject)));
    }
}

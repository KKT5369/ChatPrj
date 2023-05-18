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
        if (inputRoomTitle.text.Equals(""))
        {
            PopupData popupData = new PopupData("경고","방 이름을 설정 하세요");
            PopupManager.Instance.CreatePopup(popupData);
            return;
        }
        roomData.roomTitle = inputRoomTitle.text;
        GameType? gameType = GetGameType();
        if (gameType == null)
        {
            Debug.Log("선택된 게임이 없습니다.");
            return;
        }
        roomData.gameType = gameType;
        roomData.maxPlayer = userNumberValue.value + 1;
        
        RoomManager.Instance.CreateRoom(roomData);
        UIManager.Instance.CloseUI(gameObject);
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
        btncancel.onClick.AddListener((() => UIManager.Instance.CloseUI(gameObject)));
    }
}

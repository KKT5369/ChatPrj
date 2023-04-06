using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UILoby : MonoBehaviour
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

    private void Awake()
    {
        btnNicNameModify.onClick.AddListener((() => InputPopupManager.instance.CreatePopup<UIInputPopup>(PopupType.ModifyNicName)));
    }

    private void Start()
    {
        if (!PlayerDataManager.instance.MyNicName.Equals(""))
        {
            txtMyNicName.text = PlayerDataManager.instance.MyNicName;
        }
        else
        {
            UIManager.instance.CreateUI<UIInputPopup>();
        }
    }

    public void SetUserName()
    {
        txtMyNicName.text = PlayerDataManager.instance.MyNicName;
    }
}

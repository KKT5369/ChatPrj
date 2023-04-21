using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomItem : MonoBehaviour
{
    [SerializeField] private TMP_Text txtRoomNum;
    [SerializeField] private TMP_Text txtHostName;
    [SerializeField] private TMP_Text txtTitle;
    [SerializeField] private TMP_Text txtGameTitle;
    [SerializeField] private TMP_Text txtCurUserNum;
    [SerializeField] private TMP_Text txtMaxUserNum;

    public void SetValue(RoomData roomData)
    {
        txtRoomNum.text = roomData.roomNum.ToString();
        txtHostName.text = roomData.HostName;
        txtTitle.text = roomData.roomTitle;
        txtGameTitle.text = roomData.gameType.ToString();
        txtCurUserNum.text = "1";
        txtMaxUserNum.text = roomData.maxPlayer.ToString();

        Button btn = GetComponent<Button>();
        PopupData popupData = new PopupData() ;
        popupData.title = "입장";
        popupData.body = txtTitle.text + " 방에 입장 하시겠습니까?";
        // btn.onClick.AddListener((() => PopupManager.Instance.CreatePopup(popupData,
        //     (() => PhotonManager.Instance.JoinRoom(roomData)))));
    }
}

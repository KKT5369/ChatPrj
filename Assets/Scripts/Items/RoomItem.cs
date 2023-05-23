using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomItem : MonoBehaviour
{
    [SerializeField] private TMP_Text txtRoomNum;
    [SerializeField] private TMP_Text txtTitle;
    [SerializeField] private TMP_Text txtGameTitle;
    [SerializeField] private TMP_Text txtCurUserNum;
    [SerializeField] private TMP_Text txtMaxUserNum;

    
    
    public void SetValue(RoomData roomData)
    {
        txtRoomNum.text = roomData.roomNum.ToString();
        txtTitle.text = roomData.roomTitle;
        txtGameTitle.text = roomData.gameType.ToString();
        txtCurUserNum.text = roomData.purPlayerNum.ToString();
        txtMaxUserNum.text = roomData.maxPlayer.ToString();
        
        
        
        Button btn = GetComponent<Button>();

        btn.onClick.AddListener((() => JoinRoom(roomData)));
    }

    void JoinRoom(RoomData roomData)
    {
        PopupData popupData = new PopupData() ;
        if (txtCurUserNum.text == txtMaxUserNum.text)
        {
            popupData.title = "정원 초가";
            popupData.body = txtTitle.text + " 방은 더이상 자리가 없어요.";
            PopupManager.Instance.CreatePopup(popupData);
        }
        else
        {
            popupData.title = "입장";
            popupData.body = txtTitle.text + " 방에 입장 하시겠습니까?";
            PopupManager.Instance.CreatePopup(popupData,
                (() => RoomManager.Instance.CreateOrJoinRoom(roomData)));
        }
    }
}

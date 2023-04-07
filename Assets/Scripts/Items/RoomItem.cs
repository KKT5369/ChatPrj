using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomItem : MonoBehaviour
{
    [SerializeField] private TMP_Text txtTitle;
    [SerializeField] private TMP_Text txtGameTitle;
    [SerializeField] private TMP_Text txtCurUserNum;
    [SerializeField] private TMP_Text txtMaxUserNum;

    public void SetValue(RoomData roomData)
    {
        txtTitle.text = roomData.roomTitle;
        txtGameTitle.text = roomData.gameType.ToString();
        txtCurUserNum.text = "1";
        txtMaxUserNum.text = roomData.userNumber.ToString();

        Button btn = GetComponent<Button>();
        PopupData popupData = new PopupData() ;
        popupData.title = "미구현";
        popupData.body = "미구현";
        btn.onClick.AddListener((() => PopupManager.instance.CreatePopup(popupData)));
    }
    
}

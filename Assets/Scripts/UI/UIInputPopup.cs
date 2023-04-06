using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInputPopup : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputNicName;
    [SerializeField] private TMP_Text txtTitle;
    [SerializeField] private TMP_Text txtPlaceholder;
    [SerializeField] private TMP_Text txtWarningMessage;
    
    [SerializeField] private Button btnJoin;
    [SerializeField] private Button btnCancel;

    private void Awake()
    {
        SetTitle();
        SetOnClickEvent();
    }
    
    // 중복 닉네임 체크 기능 추가 여기말고 따로 매니저 생성
    void SetOnClickEvent()
    {
        btnJoin.onClick.AddListener((() =>
        {
            SetNicName();
        }));
        PopupData popupData = new PopupData();
        popupData.title = "알림";
        popupData.body = "취소 하시겠습니까";
        // 팝업창 띄워준후 종료로 수정
        btnCancel.onClick.AddListener(() => PopupManager.instance.CreatePopup(popupData,(() => Destroy(gameObject))));
        //inputNicName.placeholder.
    }

    void SetNicName()
    {
        string nicName = inputNicName.text;
        if (NicNameCheck(nicName))
        {
            txtWarningMessage.gameObject.SetActive(true);
            txtWarningMessage.DOKill(this);
            txtWarningMessage.text = "중복된 아이디 입니다.";
            txtWarningMessage.alpha = 1f;
            txtWarningMessage.DOFade(0, 3);
        }
        else if (nicName.Equals(""))
        {
            txtWarningMessage.gameObject.SetActive(true);
            txtWarningMessage.DOKill(this);
            txtWarningMessage.text = "닉네임을 입력하세요.";
            txtWarningMessage.alpha = 1f;
            txtWarningMessage.DOFade(0, 3);
        }
        else
        {
            txtWarningMessage.gameObject.SetActive(false);
            txtWarningMessage.alpha = 1f;
            if (InputPopupManager.instance.popupType == PopupType.ModifyNicName)
            {
                string curNicName = PlayerDataManager.instance.MyNicName;
                PlayerPrefs.DeleteKey(curNicName);
            }

            PlayerPrefs.SetString("MyNicName", nicName);
            PlayerPrefs.SetString(nicName, nicName);
            PlayerDataManager.instance.MyNicName = nicName;
            FindObjectOfType<UILoby>().SetUserName();
            Destroy(gameObject);
        }
    }

    private bool NicNameCheck(string nicName)
    {
        return PlayerPrefs.HasKey(nicName);
    }

    void SetTitle()
    {
        switch (InputPopupManager.instance.popupType)
        {
            case PopupType.CreateNicName:
                txtTitle.text = "닉네임 생성";
                break;
            case PopupType.ModifyNicName:
                txtTitle.text = "닉네임 변경";
                break;
        }
    }
    
    
    
}
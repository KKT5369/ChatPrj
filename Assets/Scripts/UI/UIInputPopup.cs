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
            switch (InputPopupManager.instance.popupType)
            {
                case PopupType.CreateNicName:
                    CreateNicName();
                    break;
                case PopupType.ModifyNicName:
                    ModifyNicName();
                    break;
            }
        }));
        
        // 팝업창 띄워준후 종료로 수정
        btnCancel.onClick.AddListener(() => UIManager.instance.CloseUI(gameObject));
        //inputNicName.placeholder.
    }

    private void ModifyNicName()
    {
        string nicName = inputNicName.text;
        string curNicName = PlayerDataManager.instance.MyNicName;
        if (NicNameCheck(nicName))
        {
            txtWarningMessage.gameObject.SetActive(true);
            txtWarningMessage.DOKill(this);
            txtWarningMessage.alpha = 1f;
            txtWarningMessage.DOFade(0, 3);
        }
        else
        {
            txtWarningMessage.gameObject.SetActive(false);
            txtWarningMessage.alpha = 1f;
            PlayerPrefs.SetString("MyNicName", nicName);
            PlayerPrefs.SetString(nicName, nicName);
            PlayerPrefs.DeleteKey(curNicName);
            PlayerDataManager.instance.MyNicName = nicName;
            FindObjectOfType<UILoby>().SetUserName();
            Destroy(gameObject);
        }
        
    }

    void CreateNicName()
    {
        string nicName = inputNicName.text;
        // 일단 플레이어 프리팹에 저장
        if (NicNameCheck(nicName))
        {
            txtWarningMessage.gameObject.SetActive(true);
            txtWarningMessage.DOKill(this);
            txtWarningMessage.alpha = 1f;
            txtWarningMessage.DOFade(0, 3);
        }
        else
        {
            txtWarningMessage.gameObject.SetActive(false);
            txtWarningMessage.alpha = 1f;
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
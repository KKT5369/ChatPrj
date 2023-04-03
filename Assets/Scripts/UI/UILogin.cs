using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UILogin : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputNicName;
    [SerializeField] private TMP_Text warningMessage;
    
    [SerializeField] private Button btnJoin;
    [SerializeField] private Button btnCancel;
    
    private void Awake()
    {
        SetOnClickEvent();
    }
    
    // 중복 닉네임 체크 기능 추가 여기말고 따로 매니저 생성
    void SetOnClickEvent()
    {
        btnJoin.onClick.AddListener((() =>
        {
            // 일단 플레이어 프리팹에 저장
            if (NicNameCheck(inputNicName.text))
            {
                warningMessage.gameObject.SetActive(true);
                warningMessage.DOKill(this);
                warningMessage.alpha = 1f;
                warningMessage.DOFade(0, 3);
            }
            else
            {
                warningMessage.gameObject.SetActive(false);
                warningMessage.alpha = 1f;
                PlayerPrefs.SetString(inputNicName.text, inputNicName.text);
            }
        }));
        
        // 팝업창 띄워준후 종료로 수정
        btnCancel.onClick.AddListener((() => Application.Quit()));
        //inputNicName.placeholder.
    }

    private bool NicNameCheck(string nicName)
    {
        return PlayerPrefs.HasKey(nicName);
    }
}

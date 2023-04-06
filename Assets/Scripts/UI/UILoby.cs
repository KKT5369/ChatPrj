using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UILoby : MonoBehaviour
{
    [SerializeField] private TMP_Text txtMyNicName;
    [SerializeField] private Button btnNicNameModify;

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

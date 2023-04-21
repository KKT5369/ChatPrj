using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPopup : MonoBehaviour
{
    [SerializeField] private TMP_Text txtTitle;
    [SerializeField] private TMP_Text txtBody;

    [SerializeField] private Button btnOkey;
    [SerializeField] private Button btnCancel;

    private void Awake()
    {
        txtTitle.text = PopupManager.Instance._popupData.title;
        txtBody.text = PopupManager.Instance._popupData.body;
        SetAddListener();
    }


    void SetAddListener()
    {
        btnOkey.onClick.AddListener((() =>
        {
            PopupManager.Instance._action?.Invoke();
            UIManager.Instance.CloseUI(gameObject);
        }));
        
        btnCancel.onClick.AddListener((() => UIManager.Instance.CloseUI(gameObject)));
    }
    
}

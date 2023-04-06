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
        txtTitle.text = PopupManager.instance._popupData.title;
        txtBody.text = PopupManager.instance._popupData.body;
        SetAddListener();
    }


    void SetAddListener()
    {
        btnOkey.onClick.AddListener((() =>
        {
            PopupManager.instance._action.Invoke();
            Destroy(gameObject);
        }));
        
        btnCancel.onClick.AddListener((() => Destroy(gameObject)));
    }
    
}

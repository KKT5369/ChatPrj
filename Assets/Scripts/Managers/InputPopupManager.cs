using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPopupManager : SingleTon<InputPopupManager>
{
    private PopupType _popupType;

    public void CreatePopup<T>(PopupType popupType)
    {
        _popupType = popupType;
        UIManager.Instance.CreateUI<T>();
    }
    
    public PopupType popupType
    {
        get => _popupType;
    }
}

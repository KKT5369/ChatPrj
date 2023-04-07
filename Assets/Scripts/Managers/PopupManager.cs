using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : SingleTon<PopupManager>
{
    public Action _action { get; private set; }
    public PopupData _popupData { get; private set; }

    public void CreatePopup(PopupData popupData,Action collback)
    {
        _popupData = popupData;
        _action = collback;
        UIManager.instance.CreateUI<UIPopup>();
    }
}

public class PopupData
{
    public string title { get; set; }
    public string body { get; set; }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : SingleTon<PlayerDataManager>
{
    public string myNicName
    {
        get => myNicName;
        set => myNicName = value;
    }

    private Dictionary<string, string> _playerNicNameList;

    public void SetPlayerList(string nicName)
    {
        _playerNicNameList.Add(nicName, nicName);
    }


}

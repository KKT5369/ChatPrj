using JetBrains.Annotations;
using UnityEngine;

public class PlayerDataManager : SingleTon<PlayerDataManager>
{
    private string _myNicName;
    public string MyNicName
    {
        get => _myNicName;
        set => _myNicName = value;
    }
}

using Photon.Pun;
using UnityEngine;

public class RoomScene :Iscene
{
    public void SceneSetting()
    {
        NetWorkManager.Instance.CreateRoom();
    }
}

using Photon.Pun;
using Photon.Realtime;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class RoomNetworkController : MonoBehaviourPunCallbacks
{   
    private RoomData _roomData;

    public override void OnJoinedRoom()
    {
        PhotonNetwork.NickName = PlayerDataManager.Instance.MyNicName;
        PhotonNetwork.CurrentRoom.IsOpen = true;

        PhotonNetwork.Instantiate("Prefabs/Player", new Vector3(), quaternion.identity);
        if (photonView.IsMine)
        {
            PhotonNetwork.Instantiate("Prefabs/UI/UIRoom", new Vector3(), quaternion.identity);
        }
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        if (message.Equals("Game full"))
        {
            PopupManager.Instance.CreatePopup(new PopupData("입장불가","삐빅! 정.원.초.과"),(() => {SceneLoadManager.Instance.LoadScene<LobyScene>();}));
        }
    }
}

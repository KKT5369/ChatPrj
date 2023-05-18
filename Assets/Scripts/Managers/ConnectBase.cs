using Photon.Pun;

public class ConnectBase : MonoBehaviourPunCallbacks
{
    private readonly string _version = "1.0";

    private void Start()
    {
        Disconnecting();
        Connect();
    }

    public void Connect()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = _version;
        PhotonNetwork.ConnectUsingSettings();
    }

    public void Disconnecting() => PhotonNetwork.Disconnect();
}

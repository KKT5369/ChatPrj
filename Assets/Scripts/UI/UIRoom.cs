using DG.Tweening;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIRoom : ConnectBase
{
    [SerializeField] private TMP_Text roomTitle;
    [SerializeField] private TMP_Text nicName;
    [SerializeField] private TMP_Text txtSystemMsg;
    [SerializeField] private RectTransform chatRect;
    [SerializeField] private TMP_Text chatItem;
    [SerializeField] private TMP_InputField inputTxt;
    [SerializeField] private Button btnExti;
    
    public PhotonView pv;

    private void Start()
    {
        SetAddlistener();
        SettingRoom();
    }

    void SettingRoom()
    {
        nicName.text = PhotonNetwork.NickName;
        roomTitle.text = PhotonNetwork.CurrentRoom.Name;
        pv.RPC(nameof(SystemMsgPopup),RpcTarget.All,PhotonNetwork.NickName);
    }

    void SetAddlistener()
    {
        btnExti.onClick.AddListener((() => {
        {
            SceneLoadManager.Instance.LoadScene<LobyScene>();
        }}));
        
        inputTxt.onEndEdit.AddListener(delegate
        {
            if(inputTxt.text.Equals("")) return;
            Send();
        });
    }

    public void Send()
    {
        string chat = $"{nicName.text} : {inputTxt.text}";
        pv.RPC(nameof(ChatRPC),RpcTarget.All,chat);
        inputTxt.text = "";
    }
    
    [PunRPC]
    void ChatRPC(string msg)
    {
        chatItem.text = msg;
        var item = Instantiate(chatItem.gameObject, chatRect);
        item.SetActive(true);
    }
    
    [PunRPC]
    public void SystemMsgPopup(string nicName)
    {
        txtSystemMsg.text = $"{nicName} 님이 두두둥장!!";
        txtSystemMsg.DOFade(0f, 3f);
    }
    
    
}

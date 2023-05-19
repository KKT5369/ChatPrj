using System.Collections.Generic;
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
    
    [Header("레디창")]
    [SerializeField] private RectTransform leadyStstusRect;
    [SerializeField] private GameObject btnReady;
    private List<GameObject> _leadyButtons = new();


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
        pv.RPC(nameof(UpdateLeadyBtn),RpcTarget.All);
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
        txtSystemMsg.alpha = 255f;
        GameObject go = txtSystemMsg.gameObject;
        go.SetActive(true);
        txtSystemMsg.text = $"{nicName} 님이 두두둥장!!";
        txtSystemMsg.DOFade(0f, 2f).OnComplete((() => go.SetActive(false)));
    }

    [PunRPC]
    public void UpdateLeadyBtn()
    {
        if (_leadyButtons.Count > 0)
        {
            foreach (var v in _leadyButtons)
            {
                Destroy(v);
            }
            _leadyButtons.Clear();            
        }
        
        Player player;
        int playersCount = PhotonNetwork.CurrentRoom.Players.Count;
        Dictionary<int,Player> players = PhotonNetwork.CurrentRoom.Players;
        for (int i = 0; i < playersCount; i++)
        {
            var go = Instantiate(btnReady, leadyStstusRect);
            go.SetActive(true);
            players.TryGetValue(i+1, out player);
            go.transform.GetChild(0).GetComponent<TMP_Text>().text = player.NickName;
            _leadyButtons.Add(go);
        }
    }
}

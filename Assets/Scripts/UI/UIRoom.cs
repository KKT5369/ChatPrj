using Class;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIRoom : MonoBehaviour
{
    [SerializeField] private TMP_Text roomTitle;
    [SerializeField] private TMP_Text nicName;
    [SerializeField] private RectTransform chatRect;
    [SerializeField] private GameObject chatItem;
    [SerializeField] private TMP_InputField inputTxt;
    [SerializeField] private Button btnExti;
    
    

    private void Start()
    {
        btnExti.onClick.AddListener((() => {
        {
            SceneLoadManager.Instance.LoadScene(new LobyScene());
        }}));
        SettingRoom();
    }

    void SettingRoom()
    {
        nicName.text = PhotonNetwork.NickName;
        roomTitle.text = PhotonNetwork.CurrentRoom.Name;
        Debug.Log($"방 번호 >> {PhotonNetwork.CurrentRoom.EmptyRoomTtl}");
    }
    
    
}

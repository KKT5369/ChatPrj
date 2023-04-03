using TMPro;
using UnityEngine;

public class UILoby : MonoBehaviour
{
    [SerializeField] private TMP_Text txtMyNicName;

    private readonly string myNicName = "MyNicName";
    private void Awake()
    {
        if (PlayerPrefs.HasKey(myNicName))
        {
            txtMyNicName.text = PlayerPrefs.GetString(myNicName);
        }
        else
        {
            Instantiate(Resources.Load<UILogin>("Prefabs/UI/UILogin"));
        }
    }

    public void SetUserName()
    {
        txtMyNicName.text = PlayerPrefs.GetString(myNicName);
    }
}

using UnityEngine;

public class UIIntro : MonoBehaviour
{
    void Start()
    {
        NetWorkManager.Instance.Connect();
        SceneLoadManager.Instance.LoadScene<LobyScene>();
    }
}

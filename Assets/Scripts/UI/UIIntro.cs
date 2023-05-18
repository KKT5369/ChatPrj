using UnityEngine;

public class UIIntro : MonoBehaviour
{
    void Start()
    {
        SceneLoadManager.Instance.LoadScene<LobyScene>();
    }
}

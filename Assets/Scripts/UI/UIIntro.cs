using Class;
using Photon.Pun;
using UnityEngine;

public class UIIntro : MonoBehaviour
{
    void Start()
    {
        SceneLoadManager.Instance.LoadScene(SceneType.LobyScene);
    }
}

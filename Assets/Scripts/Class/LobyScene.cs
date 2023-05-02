using Photon.Pun;
using UnityEngine;

namespace Class
{
    public class LobyScene : Iscene
    {
        public void SceneSetting()
        {
            //UIManager.Instance.CreateUI<UILoby>();
            PhotonNetwork.Instantiate("UILoby",new Vector3(0,0),new Quaternion());
        }
    }
}
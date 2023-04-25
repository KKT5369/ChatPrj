using Photon.Pun;

namespace Class
{
    public class LobyScene : Iscene
    {
        public void SceneSetting()
        {
            UIManager.Instance.CreateUI<UILoby>();
        }
    }
}
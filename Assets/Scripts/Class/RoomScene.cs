using UnityEditor.iOS;
using UnityEngine.SceneManagement;

namespace Class
{
    public class RoomScene : Iscene
    {
        public void SceneSetting()
        {
            UIManager.Instance.CreateUI<UIRoom>();
        }

    }
}
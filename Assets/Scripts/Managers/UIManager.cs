using UnityEngine;

public class UIManager : SingleTon<UIManager>
{
    

    public void CreateUI<T>()
    {
        GameObject go = Resources.Load<GameObject>($"Prefabs/UI/{typeof(T).Name}");
        Instantiate(go);
    }

    public void CloseUI(GameObject go)
    {
        Destroy(go);
    }
}
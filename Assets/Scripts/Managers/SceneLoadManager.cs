using System;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class SceneLoadManager : SingleTon<SceneLoadManager>
{
    private Iscene _scene;

    public Iscene Scene { get => _scene; }
    
    public void LoadScene<T>() where T : Iscene,new()
    {
        _scene = new T();
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.LoadScene("LoadingScene");
    }
    
    public void OnSceneLoaded(Scene scene,LoadSceneMode loadSceneMode)
    {
        _scene.SceneSetting();
    }
}

using System;
using Class;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : SingleTon<SceneLoadManager>
{
    private Iscene _scene;

    public Iscene Scene { get => _scene; }

    public void LoadScene<T>(T scene) where T : Iscene
    {
        _scene = scene;
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.LoadScene("LoadingScene");
    }
    
    public void OnSceneLoaded(Scene scene,LoadSceneMode loadSceneMode)
    {
        _scene.SceneSetting();
    }
}

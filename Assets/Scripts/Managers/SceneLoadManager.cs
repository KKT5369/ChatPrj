using System;
using Class;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : SingleTon<SceneLoadManager>
{
    private Iscene _scene;

    public Iscene Scene { get => _scene; }
    
    /// <summary>
    /// 제네릭으로 로딩 >> 씬로드 >> 해당씬 클래스 에서 씬 세팅.
    /// </summary>
    /// <param name="scene"></param>
    /// <typeparam name="T"></typeparam>
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

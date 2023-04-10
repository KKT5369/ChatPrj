using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : SingleTon<SceneLoadManager>
{
    private string _sceneName;
    
    public string SceneName { get => _sceneName;}
    
    public void LoadScene(SceneType sceneType)
    {
        switch (sceneType)
        {
            case SceneType.LobyScene:
                _sceneName = "LobyScene";
                break;
            case SceneType.RoomScene:
                _sceneName = "RoomScene";
                break;
            case SceneType.GameScene:
                _sceneName = "SampleScene";
                break;
        }

        SceneManager.LoadScene("LoadingScene");
    }



}

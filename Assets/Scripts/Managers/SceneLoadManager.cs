using UnityEngine.SceneManagement;

public class SceneLoadManager : SingleTon<SceneLoadManager>
{
    private SceneType _scene;

    public SceneType Scene { get => _scene; }
    
    public void LoadScene(SceneType scene)
    {
        _scene = scene;
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.LoadScene("LoadingScene");
    }
    
    public void OnSceneLoaded(Scene scene,LoadSceneMode loadSceneMode)
    {
        //_scene.SceneSetting();
    }
}

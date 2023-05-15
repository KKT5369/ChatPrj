using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UILoading : MonoBehaviour
{
    [SerializeField] private Image progressBar;

    private void Start()
    {
        StartCoroutine(nameof(SceneLoading));
    }
    
    IEnumerator SceneLoading()
    {
        Iscene scene = SceneLoadManager.Instance.Scene;
        AsyncOperation op = SceneManager.LoadSceneAsync(scene.GetType().Name);
        op.allowSceneActivation = false;

        progressBar.fillAmount = 0f;
        float timer = Time.unscaledDeltaTime;
        
        while (progressBar.fillAmount <= 1f)
        {
            progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer);
            yield return new WaitForSeconds(0.001f);
            if (progressBar.fillAmount >= 0.98f)
            {
                progressBar.fillAmount = 1f;
                yield return new WaitForSeconds(0.5f);
                op.allowSceneActivation = true;
                SceneManager.sceneLoaded += SceneLoadManager.Instance.OnSceneLoaded; 
                yield break;
            }
        }
    }
}

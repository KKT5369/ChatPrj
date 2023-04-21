using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UILoading : MonoBehaviour
{
    [SerializeField] private Image ProgressBar;

    private void Start()
    {
        StartCoroutine(nameof(SceneLoading));
    }
    
    IEnumerator SceneLoading()
    {
        Iscene scene = SceneLoadManager.Instance.Scene;
        AsyncOperation op = SceneManager.LoadSceneAsync(scene.GetType().Name);
        op.allowSceneActivation = false;

        ProgressBar.fillAmount = 0f;
        float timer = Time.unscaledDeltaTime;
        
        while (ProgressBar.fillAmount <= 1f)
        {
            ProgressBar.fillAmount = Mathf.Lerp(ProgressBar.fillAmount, 1f, timer);
            yield return new WaitForSeconds(0.001f);
            if (ProgressBar.fillAmount >= 0.98f)
            {
                ProgressBar.fillAmount = 1f;
                yield return new WaitForSeconds(0.5f);
                op.allowSceneActivation = true;
                SceneManager.sceneLoaded += SceneLoadManager.Instance.OnSceneLoaded; 
                yield break;
            }
        }
    }
}

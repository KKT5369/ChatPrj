using System;
using System.Collections;
using System.Collections.Generic;
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
        AsyncOperation op = SceneManager.LoadSceneAsync(SceneLoadManager.instance.SceneName);
        // 왜 안먹히고 맘대로 넘어가냐
        op.allowSceneActivation = false;

        ProgressBar.fillAmount = 0f;
        float timer = Time.unscaledDeltaTime;
        
        while (ProgressBar.fillAmount <= 1f)
        {
            ProgressBar.fillAmount = Mathf.Lerp(ProgressBar.fillAmount, 1f, timer);
            yield return new WaitForSeconds(0.01f);
            if (ProgressBar.fillAmount >= 0.98f)
            {
                ProgressBar.fillAmount = 1f;
                yield return new WaitForSeconds(0.5f);
                op.allowSceneActivation = true;
                yield break;
            }
        }

    }
}

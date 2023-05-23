using System;
using System.Collections;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UILoading : MonoBehaviour
{
    [SerializeField] private TMP_Text title;
    [SerializeField] private Image progressBar;

    private void Start()
    {
        StartCoroutine(nameof(SceneLoading));
    }
    
    IEnumerator SceneLoading()
    {
        SceneType scene = SceneLoadManager.Instance.Scene;
        AsyncOperation op = SceneManager.LoadSceneAsync(scene.ToString());
        op.allowSceneActivation = false;
        progressBar.fillAmount = 0f;

        // while(!NetworkConnectingCheck(scene))
        // {
        //     yield return null;
        // }

        title.text = "준비가 거이다 끝났어요!";
        float timer = Time.unscaledDeltaTime;
        
        while (progressBar.fillAmount <= 1f)
        {
            progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer);
            yield return new WaitForSeconds(0.0001f);
            if (progressBar.fillAmount >= 0.89f && op.progress >= 0.89f)
            {
                progressBar.fillAmount = 1f;
                yield return new WaitForSeconds(0.5f);
                op.allowSceneActivation = true;
                SceneManager.sceneLoaded += SceneLoadManager.Instance.OnSceneLoaded; 
                yield break;
            }
        }
    }

    bool NetworkConnectingCheck(SceneType sceneType)
    {
        switch (sceneType)
        {
            case SceneType.LobyScene:
                title.text = "로비로 연결중 입니다...";
                progressBar.fillAmount = 0.2f;
                return NetWorkManager.Instance.IsLoby;
            case SceneType.RoomScene:
                title.text = "방으로 이동중 입니다...";
                progressBar.fillAmount = 0.2f;
                return NetWorkManager.Instance.IsRoom;
        }
        return false;
    }
}

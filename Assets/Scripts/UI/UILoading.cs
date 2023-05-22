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
        title.text = "서버에 연결중 입니다...";
        while (NetWorkManager.Instance.ConnectedCheck() == false)
        {
            yield return progressBar.fillAmount = 0.1f;
        }
        
        title.text = "로딩중...";

        Iscene scene = SceneLoadManager.Instance.Scene;
        AsyncOperation op = SceneManager.LoadSceneAsync(scene.ToString());
        // if (op == null)
        // {
        //     SceneManager.LoadScene("LobyScene");
        // }
        op.allowSceneActivation = false;

        progressBar.fillAmount = 0f;
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
}

using System.Collections;
using System.Collections.Generic;
using Class;
using UnityEngine;

public class UIIntro : MonoBehaviour
{
    void Start()
    {
        SceneLoadManager.Instance.LoadScene(new LobyScene());
    }
}

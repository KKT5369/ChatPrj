using System;
using System.Collections;
using System.Collections.Generic;
using Class;
using UnityEngine;
using UnityEngine.UI;

public class UIRoom : MonoBehaviour
{
    [SerializeField]private Button btnExti;

    private void Start()
    {
        btnExti.onClick.AddListener((() => {SceneLoadManager.instance.LoadScene(new LobyScene());}));
    }
}

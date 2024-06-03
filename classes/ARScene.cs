using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ARScene : MonoBehaviour
{
    public UnityEngine.UI.Button arScene;
    void Start()
    {
        arScene.onClick.AddListener(loadARScene);

    }



    private void loadARScene()
    {
        SceneManager.LoadScene("arScene");
    }
}

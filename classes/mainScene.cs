using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainScene : MonoBehaviour
{
    public UnityEngine.UI.Button goMain;
    // Start is called before the first frame update
    void Start()
    {
        goMain.onClick.AddListener(loadMainScene);

    }



    private void loadMainScene()
    {
        SceneManager.LoadScene("main");
    }
}
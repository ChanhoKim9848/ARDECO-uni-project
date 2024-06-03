using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quit : MonoBehaviour
{

    public UnityEngine.UI.Button quitButton;


    // Start is called before the first frame update
    void Start()
    {
        quitButton.onClick.AddListener(quitFunction);
    }

    private void quitFunction()
    {
        Application.Quit();
    }

}

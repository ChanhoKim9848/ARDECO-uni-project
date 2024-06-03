using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public UnityEngine.UI.Button goTutorial;
    // Start is called before the first frame update
    void Start()
    {
        goTutorial.onClick.AddListener(loadTutorial);

    }



    private void loadTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
}

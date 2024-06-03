using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Height : MonoBehaviour
{
    private bool holding;
    public Button HeightButton;
    public Button DisableButton;

    public bool buttonclicked = false;
    public bool disableclicked = false;


    public Rotate rotate;
    public Delete delete;
    public Translate translate;



    void Start()
    {
        holding = false;
        HeightButton.onClick.AddListener(ButtonFunction);
        DisableButton.onClick.AddListener(DisableFunction);


        rotate = GetComponent<Rotate>();
        delete = GetComponent<Delete>();
        translate = GetComponent<Translate>();

    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

    private void DisableFunction()
    {
        disableclicked = true;
    }

    private void ButtonFunction()
    {
        buttonclicked = true;
        rotate.buttonclicked = false;
        delete.buttonclicked = false;
        translate.buttonclicked = false;
        disableclicked = false;


    }

    void Update()
    {

        if (holding && buttonclicked == true &&
            disableclicked == false &&
            IsPointerOverUIObject() == false)
        {
                HeightFunction();
        }

        // One finger
        if (Input.touchCount == 1)
        {

            // Tap on Object
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100f))
                {
                    if (hit.transform == transform)
                    {
                        holding = true;
                    }
                }
            }

            // Release
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                holding = false;
            }
        }
    }

    void HeightFunction()
    {

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        // The GameObject this script attached should be on layer "Surface"
        if (Physics.Raycast(ray, out hit, 30.0f, LayerMask.GetMask("Surface")))
        {
            transform.position = new Vector3(transform.position.x,
                                             hit.point.y,
                                             transform.position.z);
        }

    }
}


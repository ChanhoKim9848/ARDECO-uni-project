using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ARFunction : MonoBehaviour
{
    public GameObject[] placementIndicator;

    //private ARSessionOrigin arOrigin;
    private Pose placementPose;
    private bool placementPoseIsValid = false;
    private ARRaycastManager aRRaycastManager;


    public GameObject[] objectToPlace;
    public UIFunction call;

    public bool On = false;

    public UnityEngine.UI.Button OnButton;
    public UnityEngine.UI.Button OffButton;
    public UnityEngine.UI.Button CleanButton;




    void Start()
    {

        
        OnButton.onClick.AddListener(OnFunction);
        OffButton.onClick.AddListener(OffFunction);
        CleanButton.onClick.AddListener(CleanFunction);

        call = GetComponent<UIFunction>();
      


    }
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }


    void OnFunction()
    {

        On = true;

        if (call.selected == true)
        {
            aRRaycastManager = FindObjectOfType<ARRaycastManager>();
            placementIndicator[call.index].SetActive(true);
        }

    }



    void OffFunction()
    {
        On = false;

    }

    void CleanFunction()
    {
        SceneManager.LoadScene("arScene");
    }





    void Update()
    {
        UpdatePlacementPose();
        UpdatePlacementIndicator();
        if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && On == true)
        {
            // Check if finger is over a UI element
            if (IsPointerOverUIObject() == false)
            {
                PlaceObject();
            }

        }
    }

    private void PlaceObject()
    {

            Instantiate(objectToPlace[call.index], placementPose.position, placementPose.rotation);

    }

    private void UpdatePlacementIndicator()
    {
        if (placementPoseIsValid && On == true)
        {
            placementIndicator[call.index].SetActive(true);
            placementIndicator[call.index].transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        {
            placementIndicator[call.index].SetActive(false);

        }
    }

    private void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            placementPose = hits[0].pose;
        }
    }
}



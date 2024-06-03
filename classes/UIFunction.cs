using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class UIFunction : MonoBehaviour
{
    public Text result;
    public Dropdown dropdown;
    public string[] objects = new string[]{};
    public int index;

    public bool selected = false;

    public Button button;
    

    void Start()
    {
        SetFunction_UI();
    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }





    private void SetFunction_UI()
    {
        //Reset
        ResetFunction_UI();

        button.onClick.AddListener(Function_Button);
        dropdown.onValueChanged.AddListener(delegate {
            Function_Dropdown(dropdown);
        });
    }

    public void Function_Button()
    {
        string op = dropdown.options[dropdown.value].text;
        result.text = op;

        index = Array.IndexOf(objects, op);
        selected = true;
    }



    private void Function_Dropdown(Dropdown select)
    {
        string op = select.options[select.value].text;
    }

    private void ResetFunction_UI()
    {
        button.onClick.RemoveAllListeners();
        dropdown.onValueChanged.RemoveAllListeners();
        dropdown.options.Clear();

        for (int i = 0; i < objects.Length; i++)
        {
            Dropdown.OptionData newData = new Dropdown.OptionData();
            newData.text = objects[i];
            dropdown.options.Add(newData);
        }
        dropdown.SetValueWithoutNotify(-1);
        dropdown.SetValueWithoutNotify(0);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutlineController : MonoBehaviour
{
    private Outline _outline;
    public string objName;
    public GameObject uiText;
    void Start()
    {
        uiText = GameObject.Find("Object Name UI");
        _outline = GetComponent<Outline>();
        _outline.enabled = false;
    }

    private void OnMouseEnter()
    {
        if (_outline != null)
        {
            uiText.GetComponent<Text>().text = objName;
            _outline.enabled = true;
        }
    }

    private void OnMouseExit()
    {
        if (_outline != null && _outline.isActiveAndEnabled)
        {
            uiText.GetComponent<Text>().text = "";
            _outline.enabled = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineController : MonoBehaviour
{
    private Outline _outline;
    void Start()
    {
        _outline = GetComponent<Outline>();
        _outline.enabled = false;
    }

    private void OnMouseEnter()
    {
        if (_outline != null)
        {
            _outline.enabled = true;
        }
    }

    private void OnMouseExit()
    {
        if (_outline != null && _outline.isActiveAndEnabled)
        {
            _outline.enabled = false;
        }
    }
}

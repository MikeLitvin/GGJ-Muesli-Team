using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceShowing : MonoBehaviour
{
    public GameObject choice1;

    public GameObject choice2;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            choice1.gameObject.SetActive(true);
            choice2.gameObject.SetActive(true);
        }
    }
}

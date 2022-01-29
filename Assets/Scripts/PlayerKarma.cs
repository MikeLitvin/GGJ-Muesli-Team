using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerKarma : MonoBehaviour
{
    private int karmaValue;
    public GameObject uiText;
    
    public string goodObjectDescription;
    public GameObject goodObjectUI;
    
    public string badObjectDescription;
    public GameObject badObjectUI;
    void Start()
    {
        karmaValue = 50;
        uiText = GameObject.Find("Karma Text");
        uiText.GetComponent<Text>().text = "Карма: " + karmaValue.ToString() + "%";
        SetDescriptions();
    }
    

    void SetDescriptions()
    {
        string[] choices = new string[] {"First Button", "Second Button"};
        goodObjectUI = GameObject.Find(choices[0]);
        goodObjectUI.GetComponentInChildren<Text>().text = goodObjectDescription;
        badObjectUI.gameObject.SetActive(false);
        
        
        badObjectUI = GameObject.Find(choices[1]);
        badObjectUI.GetComponentInChildren<Text>().text = badObjectDescription;
        badObjectUI.gameObject.SetActive(false);
    }
}

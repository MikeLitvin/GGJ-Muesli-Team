using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ChoiceShowing : MonoBehaviour
{

    public GameObject player;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.GetComponent<NavMeshAgent>().isStopped = true;
            var karma = player.GetComponent<PlayerKarma>();
            
            var goodChoice = karma.GetComponent<PlayerKarma>().goodObjectUI;
            var badChoice = karma.GetComponent<PlayerKarma>().badObjectUI;
            
            goodChoice.gameObject.SetActive(true);
            badChoice.gameObject.SetActive(true);
        }
    }

    public void GoodButtonPressed()
    {
        var karma = player.GetComponent<PlayerKarma>();
        karma.karmaValue += 50;
        karma.uiText.GetComponent<Text>().text = "Карма: " + karma.karmaValue.ToString() + "%";
    }

    public void BadButtonPressed()
    {
        var karma = player.GetComponent<PlayerKarma>();
        karma.karmaValue -= 50;
        karma.uiText.GetComponent<Text>().text = "Карма: " + karma.karmaValue.ToString() + "%";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void PlayButtonPressed()
    {
        SceneManager.LoadScene("Scenes/GameScene");
    }
}

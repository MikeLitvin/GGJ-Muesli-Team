using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 _lastPos;
    public GameObject player;
    public bool isMoved;
 
    void Update ()
    {
        var position = player.transform.position;
        isMoved = position != _lastPos;
        _lastPos = position;
    }
}

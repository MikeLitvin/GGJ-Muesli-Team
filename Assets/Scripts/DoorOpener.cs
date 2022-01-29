using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public Animator animator;

    public void OpenDoor()
    {
        animator.Play("Door_OpenDoorAction");
    }
}

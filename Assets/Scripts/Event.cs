using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum EventType
{
    GOOD, BAD
}

public class Event : MonoBehaviour
{
    EventType type;
    string description;
}

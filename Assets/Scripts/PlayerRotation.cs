using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public double dx;
    public double dy;
    public bool isActive = true;
    void Update () {
        if (isActive)
        {
            dx = Input.mousePosition.x - Screen.width / 2.0;
            dy = Input.mousePosition.y - Screen.height / 2.0;
            float sdx = (float)dx;
            float sdy = (float)dy;
            float rotationspeed = 150f;

            float sR = Mathf.Atan2(sdx, sdy);
            float sD = 360 * sR / (2 * Mathf.PI);

            float startAngle_x = transform.rotation.eulerAngles.x;
            float startAngle_y = sD;
            float startAngle_z = transform.rotation.eulerAngles.z;

            Quaternion target = Quaternion.Euler(startAngle_x, sD, startAngle_z);
            transform.rotation = Quaternion.RotateTowards(transform.rotation,
                target,
                Time.deltaTime * rotationspeed);
        }
    }
}

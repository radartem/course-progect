using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Scroll : MonoBehaviour
{
    [SerializeField]
    float scrollSpeed = 10f;
    [SerializeField]
    int sensivity = 3;

    int maxdistance = 25;
    int mindistance = 1;

    [SerializeField]
    Transform targetPos;

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal"); // кнопки A D
        float y = Input.GetAxis("Vertical"); // кнопки W S

        if (x != 0 || y != 0)
        {
            Vector3 newpos = transform.position + (transform.TransformDirection(new Vector3(x, 0, 0)) + Vector3.up * y) / sensivity;
            if (ControlDistance(Vector3.Distance(newpos, targetPos.position))) transform.position = newpos;
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            Vector3 newpos = transform.position + transform.TransformDirection(Vector3.forward * Input.GetAxis("Mouse ScrollWheel") * scrollSpeed);
            if (ControlDistance(Vector3.Distance(newpos, targetPos.position))) transform.position = newpos;
        }
       
        if (Input.GetMouseButton(1))
        {
            transform.RotateAround(targetPos.position, Vector3.up, Input.GetAxis("Mouse X")*sensivity);
            transform.Rotate(Vector3.left, Input.GetAxis("Mouse Y")*sensivity);            
        }
    }

    bool ControlDistance (float distance)
    {
        if (distance > mindistance && distance < maxdistance) return true;
        return false;
    }
    
}

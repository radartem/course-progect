using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDrug : MonoBehaviour {

    float sensivity = 50f;
    
    float minAngle = 15f;
    float maxAngle = 105f;

    float previousAngle;

    private void Start()
    {
        EventManager.ChangeColor(Color.green);
    }

    private void OnMouseDrag()
    {
        float newz = Input.GetAxis("Mouse X") * sensivity + transform.eulerAngles.z;
        CalculalteAngle(newz);
    }

    void CalculalteAngle(float angle)
    {
        angle = Mathf.Clamp(angle, minAngle, maxAngle);
        angle = (float)System.Math.Round(angle / 20) * 20;
        
        if (angle!=previousAngle)
        {
            transform.localEulerAngles = new Vector3(0, -90, angle);
            previousAngle = angle;
            EventManager.ChangeColor(CalculateColor(angle));
        }
        
        
        // EventManager.ChangeColor()
    }

    Color CalculateColor(float angle)
    {
        switch ((int)angle)
        {
            case 20: return Color.white;
            case 40: return Color.blue;
            case 60: return Color.yellow;          
            case 80: return Color.green;
            case 100: return Color.red;
            default: return Color.white;

        }
    }

}

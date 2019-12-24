using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replacer : MonoBehaviour
{
    bool move = false;
    Vector3 startPosition;
    Vector3 needPosition;
    float speed = 0.01f;
    float offset = 0;
    Quaternion startRotation;
    Quaternion needRotaton;

    bool switching;

    private void OnEnable()
    {
        EventManager.Moved += Move;
    }

    private void Move()
    {
        if(!move)
        {
            move = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
            needPosition = new Vector3(-19.5f, 3.9f, -24.6f);
            needRotaton = new Quaternion(0, 0.7f, 0, 0.7f);
            switching = true;
        }
       
    }

    public void MoveTo(Transform t)
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
        needPosition = t.transform.position;
        needRotaton = t.transform.rotation;
        offset = 0;
        move = true;
    }

    void FixedUpdate()
    {

        if(move)
        {
            offset+=speed;
            transform.position = Vector3.Lerp(startPosition, needPosition, offset);
            transform.rotation = Quaternion.Lerp(startRotation, needRotaton, offset);            
            
            if (offset >= 1)
            {
                move = false;
                offset = 0;
                print("вызываем событие по окончанию движения");
                if (switching)
                {
                    switching = false;
                    EventManager.SwitchCanvas(false);
                }
            }
        }
    }
}

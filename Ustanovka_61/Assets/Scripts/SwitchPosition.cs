using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPosition : MonoBehaviour 
{
    [SerializeField]
    Transform targetPos;

    [SerializeField]
    Transform arrowOblect;


    private enum State 
        {
        off,
        on,
        turnToOff,
        turnToOn
        }

    State state = State.off;

    void OnEnable()//при включении/содании объекта
    {
        //currentPos = transform.localPosition.y;
        EventManager.Switch += ChangeState;//подписались на событие 
    }
  
    void ChangeState(bool work)
    {
        if (work && state == State.off) state = State.turnToOn;
        else if (!work && state == State.on) state = State.turnToOff;
    }

    void FixedUpdate()
    {
        
        if (state == State.turnToOn)
        {
            StartCoroutine(TrigerRotate(-1));
            state = State.on;
        }

        if (state == State.turnToOff)
        {
            StartCoroutine(TrigerRotate(1));
            state = State.off;
        }
    }

    IEnumerator TrigerRotate(int side)
    {
        for(int j=0;j<2;j++)
        {
            switch(j)
            {
                case 0:
                    for (int i = 0; i < 5; i++)
                    {
                        transform.RotateAround(targetPos.position, Vector3.right, side * 16f);
                        yield return new WaitForSeconds(0.05f);
                    }
                    break;
                case 1:
                    for (int i = 0; i < 10; i++)
                    {
                        arrowOblect.Rotate(new Vector3(0, 0, side * (-10f)));
                        yield return new WaitForSeconds(0.05f);
                    }
                    break;
            }
        }
    }

}





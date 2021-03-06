﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchColor : MonoBehaviour
{
    [SerializeField]
    Transform targetPos;

    [SerializeField]
    new Image pattern;
    private enum State
    {
        green=1,
        yellow,
    }
    State state;

    void Start()
    {
        EventManager.ChangeColor(Color.green);
        state = State.green;

    }
    private void OnMouseDown()
    {
        Debug.Log("Start " + state);
        switch(state)
        {
            case State.yellow:
                {
                    StartCoroutine(TrigerRotate(1));
                    pattern.rectTransform.sizeDelta = new Vector2(700F,600F);
                    EventManager.ChangeColor(Color.green);
                    state = State.green;
                }
                break;
            case State.green:
                {
                    StartCoroutine(TrigerRotate(-1));
                    pattern.rectTransform.sizeDelta = new Vector2(750F, 600F);
                    EventManager.ChangeColor(Color.yellow);
                    state = State.yellow;
                }
                break;
        }
        Debug.Log("End "+state);

    }

    IEnumerator TrigerRotate(int side)
    {
        for (int i = 0; i < 5; i++)
        {
            transform.RotateAround(targetPos.position, Vector3.right, side * 16f);
            yield return new WaitForSeconds(0.05f);
        }
    }


    void ChangeSize(Image patt, float value)
    {
        
    }
}





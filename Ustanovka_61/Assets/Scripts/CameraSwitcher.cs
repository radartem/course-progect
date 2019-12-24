using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraSwitcher : MonoBehaviour
{
    [SerializeField]
    GameObject interferencePattern;

    [SerializeField]
    GameObject main;

    private void OnMouseDown()
    {
        EventManager.MovedCamera();//вызываем событие для камеры для начала движения
        EventManager.SwitchCan += Switch;//подписываемся на событие для переключения камер
    }

    private void Start()
    {
        interferencePattern.SetActive(false);
    }

    public void Switch(bool onMain)
    {
        
        print("вызван switch c "+onMain);
        if (onMain)
        {
            print("переключаемся на главную");
            //main.SetActive(true);
            interferencePattern.SetActive(false);
        }

        else
        {
            print("переключаемся с главной");
            //main.SetActive(false);
            interferencePattern.SetActive(true);
        }
       
    }
    
}

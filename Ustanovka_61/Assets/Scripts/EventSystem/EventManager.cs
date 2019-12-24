using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    public delegate void SwitchHandler(bool work);//включение установки
    public delegate void MoveHandler();//перемещние камеры к окуляру
    public delegate void SwitchCamerasHandler(bool main);//смена камер
    public delegate void HandlerColorChanger(Color color);//поворот линзы
    public delegate bool HandlerValues();//запись в таблицу

    public static event SwitchHandler Switch;//переключение
    public static event SwitchHandler SwitchMagn;//переключение
    public static event MoveHandler Moved;//перемещение
    public static event SwitchCamerasHandler SwitchCan;//перемещение
    public static event HandlerColorChanger ColorChanger;//смена цвета
    public static event HandlerValues WritingValue;//смена цвета

    private void Start()
    {
        Switch(false);
    }

    public static void SwitchWork(bool work)//просто метод, который будет вызвать событие
    {
        Switch(work);//вызываем событие для подписчиков
    }

    public static void SwitchMagnifier(bool MaginOn)//просто метод, который будет вызвать событие
    {
        SwitchMagn(MaginOn);//вызываем событие для подписчиков
    }

    public static void MovedCamera()//просто метод, который будет вызвать событие
    {
        Moved();//вызываем событие для подписчиков
    }

    public static void SwitchCanvas(bool onMain)
    {
        print("вызвано событие через менеджер");
        SwitchCan(onMain);
    }

    public static void ChangeColor(Color color)
    {
        ColorChanger(color);
    }

    public static bool WriteValue()
    {
        if (WritingValue())
        {
            return true;
        }
        else return false;
    }


    public static float ToPersent(float min, float max, float value)
    {
        return Mathf.Abs((min - value) / (max - min));
    }

    public static float FromPersent(float min, float max, float persent)
    {
        return (max-min)*persent+min;
    }
}

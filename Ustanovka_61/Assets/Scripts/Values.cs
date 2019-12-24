using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Values : MonoBehaviour {

    [SerializeField]
    TextMesh myText;

    void OnEnable()//при включении/содании объекта
    {
       // EventManager.Rotate += ChangeValue;//подписались на событие 
    }

    private void OnDisable()//при выключении/удалении объекта
    {
       // EventManager.Rotate -= ChangeValue;//подписались на событие 
    }
 
    void ChangeValue(float alpha)
    {
        print("пришло значение" + alpha);
        float newvalue = alpha * Mathf.Deg2Rad;
        newvalue = 266f * ((1+Mathf.Cos(2*newvalue))/2)+Random.Range(-5,5);
        print("значение до округления" + newvalue);
        newvalue = Mathf.Round(newvalue);
        if (newvalue < 0) newvalue = 0;
        myText.text = newvalue + "мА";
        //myText.text = newvalue.ToString();
    }


}

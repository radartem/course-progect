using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : MonoBehaviour {

    bool work = false;

    private void OnMouseDown()
    {
        work = !work;
        Power(work);
    }   

    public void Power(bool work)
    {
        EventManager.SwitchWork(work);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ColorChanger : MonoBehaviour
{
    new Image renderer;
    Color memoryColor;
    
    private void Start()
    {
        renderer = GetComponent<Image>();
        renderer.enabled = false;
        EventManager.Switch += Render;
        EventManager.ColorChanger += ChangeColor;//подписываемся на событие для переключения камер
    }

    private void Render(bool work)
    {
        if (!work)
        {
            renderer.enabled = false;
        }
        else
        {
            renderer.enabled = true;
            renderer.color = memoryColor;
        }
    }
    
    void ChangeColor(Color color)
    {
        if (renderer.enabled) renderer.color = color;
        memoryColor = color;
    }
}

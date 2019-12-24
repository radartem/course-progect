﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Info data", menuName = "ScriptInfo", order = 51)]
public class Info : ScriptableObject {

    [SerializeField]
    private string information;

    [SerializeField]
    private Sprite image;

    public string GetInfo()
    {
        return information;
    }

    public Sprite GetImage()
    {
        return image;
    }
}

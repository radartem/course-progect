using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowByCursor : MonoBehaviour {
    /*
    [SerializeField]
    Texture2D startcursor;

    [SerializeField]
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    */
    [SerializeField]
    private Info infoData;


    [SerializeField]
    TextPanel Panel;

    private void Start()
    {
        //Cursor.SetCursor(startcursor, Vector2.zero, cursorMode);
        //changer = GetComponent<MaterialChanger>();
    }
    
    void OnMouseEnter()
    {
        //Cursor.SetCursor(cursorTexture, Vector2.zero, cursorMode);
        if (infoData != null)
        {
            if (infoData.GetImage() != null) Panel.Open(infoData.GetImage());
            else Panel.Open(infoData.GetInfo());
        }
        else Panel.Open("");
    }
    void OnMouseExit()
    {
        //Cursor.SetCursor(startcursor, Vector2.zero, cursorMode);
        //changer.BackMaterials();
        Panel.Close();
    }
}


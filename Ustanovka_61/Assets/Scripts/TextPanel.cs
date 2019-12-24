using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPanel : MonoBehaviour {


    Text text;
    Image img;
    Image extraimg;
    GameObject child;

    void Start () {

        text = GetComponentInChildren<Text>();
        extraimg = GameObject.Find("ExtraImage").GetComponent<Image>();
        extraimg.enabled = false;
        //text.text = "";
        img = GetComponent<Image>();
        img.enabled = false;
        child = transform.GetChild(0).gameObject;
        child.SetActive(false);

	}

    public void Open(string message)
    {
       // print("На " + gameObject.name + message);
        if(message.Length != 0)
        {
            //print("перезапись");
            text.text = message;
        }
        
        img.enabled = true;
        extraimg.enabled = false;
        child.SetActive(true);
    }

    public void Open (Sprite image)
    {
        extraimg.sprite = image;
        extraimg.enabled = true;
        //text.text = "";
        img.enabled = true;
        child.SetActive(true);
    }
   
    public void Close()
    {
        //text.text = "";
        img.enabled = false;
        extraimg.enabled = false;
        child.SetActive(false);
    }
}

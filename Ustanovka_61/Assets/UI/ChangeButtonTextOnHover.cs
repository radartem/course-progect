using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangeButtonTextOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    [SerializeField]
    private Info infoData;

    [SerializeField]
    MaterialChanger joinObject;

    [SerializeField]
    TextPanel Panel;
    
    [SerializeField]
    private Transform anchorObject;

    Replacer camera;

    [SerializeField]
    Font fontRegular;

    [SerializeField]
    Font fontMedium;

    Text text;

    void Start()
    {
        text = GetComponentInChildren<Text>();
        camera = FindObjectOfType<Replacer>();

    }
    public void OnPointerEnter(PointerEventData eventData)
    {

        text.color = new Color(1, 0.576f, 0);
        text.font = fontMedium;

        if (joinObject != null)
        {
            joinObject.HighLightObject();
        }

        if (infoData != null)
        {
            if (infoData.GetImage() != null) Panel.Open(infoData.GetImage());
            else Panel.Open(infoData.GetInfo());
        }
        else Panel.Open("");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (joinObject != null)
        {
            camera.MoveTo(anchorObject);
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        PointerOut();
    }

    public void PointerOut()
    {
        text.color = new Color(0, 0, 0);
        text.font = fontRegular;

        if(joinObject!=null) joinObject.BackMaterials();
        Panel.Close();
    }
}

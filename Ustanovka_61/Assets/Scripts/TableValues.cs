using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableValues : MonoBehaviour
{
    [SerializeField]
    Text[] yellowNn;

    [SerializeField]
    Text[] greenNn;

    [SerializeField]
    Text yellowDX;

    [SerializeField]
    Text greenDX;

    [SerializeField]
    Text yellowZ;

    [SerializeField]
    Text greenZ;

    [SerializeField]
    Text yellowH;

    [SerializeField]
    Text greenH;

    [SerializeField]
    Text yellowLm;

    [SerializeField]
    Text greenLm;

    [SerializeField]
    Text D;

    [SerializeField]
    InputField textInput;

    
    void Start()
    {
    }

    bool isColorYellow = true;

    static int counter = 0;
    public void WriteValue()
    {

        string valueText = textInput.text;
        double newValue = 0;

        if (!double.TryParse(valueText, out newValue) && (newValue % 1 == 0) && newValue != 0)
        {
            textInput.text = "";
            return;
        }
        if (isColorYellow)
        {
            FillIn(yellowNn, yellowZ, yellowDX, yellowH, yellowLm);
            if (yellowZ.text != "----")
                isColorYellow = false;
        }
        else
            FillIn(greenNn, greenZ, greenDX, greenH, greenLm);
        textInput.text = "";
        void FillIn(Text[] Nn, Text Z, Text DX, Text H, Text Lm)
        {
            double gamVal = 0.042;
            double dx = 0;
            double d = 0;
            double h = 0;
            double a = 0.773;
            double b = 0.135;
            double l = 0.985;
            double lm = 0;
            if (EventManager.WriteValue())
            {
                if (counter < 3)
                {
                    Nn[counter].text = newValue.ToString("f2");
                    counter++;
                    if (counter == 3)
                    {
                        double val = 0;
                        foreach (var v in Nn)
                            val += double.Parse(v.text);
                        dx = val / 3 * gamVal;
                        DX.text = dx.ToString("f2");
                    }
                }
                else
                {
                    double val = 0;
                    foreach (var v in Nn)
                        val += double.Parse(v.text);
                    dx = val / 3 * gamVal;

                    Z.text = newValue.ToString("f0");
                    counter = 0;
                    h = newValue * gamVal;
                    H.text = h.ToString("f2");
                    d = a * h / b;
                    D.text = "d = " + d.ToString("f2") + "мм";
                    lm = dx / l * d*1000;
                    Lm.text = lm.ToString("f1");
                }
            }
        }
    }

    public void Clean()
    {
        yellowNn[0].text="---";
        yellowNn[1].text = "---";
        yellowNn[2].text = "---";

        greenNn[0].text = "---";
        greenNn[1].text = "---";
        greenNn[2].text = "---";

        yellowDX.text="----";

        greenDX.text="----";

        yellowZ.text="----";

        greenZ.text="----";

        yellowH.text="----";

        greenH.text="----";

        yellowLm.text="----";

        greenLm.text="----";

        D.text="----";

        textInput.text="";
}
}
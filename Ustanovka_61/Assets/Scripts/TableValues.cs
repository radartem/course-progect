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

   

    Text[][] matrix = new Text[12][];

    

    float y = 0.0283f;//мм
    const double gamVal= 0.042;//mm
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
            FillIn(yellowNn, yellowZ, yellowDX);
            if(yellowZ.text!="----")
                isColorYellow = false;
        }
        else 
            FillIn(greenNn, greenZ, greenDX);

        void FillIn(Text[] Nn,Text Z,Text DX)
        {
            if (counter < 3)
            {
                Nn[counter].text = newValue.ToString("f4");
                counter++;
               if(counter==3)
                {
                    double val = 0;
                    foreach (var v in Nn)
                        val += double.Parse(v.text);
                    DX.text = (val / 3 * gamVal).ToString("f4");

                }
            }
            else
            {
                Z.text = newValue.ToString("f0");
                counter = 0;
            }

        }

        //if (green1[0].text == "_")
        //{
        //    //print("попали сюда" + " в инпуте " + valueText);
        //    if (EventManager.WriteValue()) green1[0].text = newValue.ToString();
        //    else return;

        //}
        //else if (green2[0].text == "_")
        //{
        //    if (EventManager.WriteValue()) green2[0].text = newValue.ToString();
        //    else return;
        //}
        //else if (green3[0].text == "_")
        //{
        //    if (EventManager.WriteValue()) green3[0].text = newValue.ToString();
        //    else return;
        //    CalculateR();
        //}
        //else 
        //{       
        //    for(int i = 3; i<matrix.Length;i++)
        //    {
        //        if(matrix[i][0].text == "_")
        //        {
        //            if (!EventManager.WriteValue()) return;

        //            matrix[i][0].text = newValue.ToString();
        //            float Dm = CalculateDm(newValue);
        //            matrix[i][1].text = Dm.ToString("0.000");
        //            float D2 = CalculateD2(Dm);
        //            matrix[i][2].text = D2.ToString("0.000"); 

        //            if (i == 5 || i==8 || i == 11)
        //            {
        //                int l = CalculateL(Convert.ToSingle(matrix[i - 2][2].text), Convert.ToSingle(matrix[i - 1][2].text), this.R);
        //                for(int j = i-2; j<=i; j++)
        //                {
        //                    matrix[j][3].text = l.ToString();
        //                }
        //            }
        //            break;
        //        }    
        //    }
        //}
        textInput.text="";
    }
   
    float CalculateDm(int Nm)
    {
        return Nm * y;//в мм
    }

    float CalculateD2(float Dm)
    {
        return Dm * Dm;  //в мм2      
    }

    void CalculateR()
    {
        float R = 0;
        for(int m=0; m<3; m++)
        {
            Text[] t = matrix[m];            
            float Dm = CalculateDm(Convert.ToInt32(t[0].text));            
            float Dm2 = CalculateD2(Dm);            
            float currentR = (Dm2) / (4 * (m + 1) * 0.000525f)/1000;//получим в мм        
            R += currentR;            
            t[1].text = Dm.ToString("0.000");
            t[2].text = Dm2.ToString("0.000");                   
        }
        R /= 3;
        //this.R = R;
        //this.Rtext.text = "R = " + R.ToString("0.00")+ "м";
    }

    int CalculateL(float D2ring1, float D2ring2, float R)
    {
        //print(D2ring2 / 1000000);
        float l = ((D2ring2 - D2ring1) / (4 * R /1000));
        return (int)(l);
    }


    public void Clean()
    {
        foreach (Text[] t in matrix)
        {
            for(int i = 0; i<t.Length; i++)
            {
                t[i].text = "_";
            }           

        }
    }
}

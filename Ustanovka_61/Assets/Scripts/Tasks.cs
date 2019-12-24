using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tasks : MonoBehaviour
{

    [SerializeField]
    Text taskText;
    Image myimage;

    [SerializeField]
    Text nameOfColor;

    [SerializeField]
    Button addButton;
    [SerializeField]
    Image addButtonImage;

    [SerializeField]
    Button tableButton;
    [SerializeField]
    Image tableButtonImage;
    [SerializeField]

    Button clearTableButton;
    [SerializeField]
    Image clearTableButtonImage;

    [SerializeField]
    GameObject inputArea;

    bool isWorking;
    Color currentColor;

    bool wasTaskControl;
    bool trigerMagnifier;
    int numberOfTask = 0;

    private void Start()
    {
        myimage = GetComponent<Image>();
        myimage.enabled = false;
        taskText.enabled = false;
        nameOfColor.enabled = false;
        addButton.GetComponent<Image>().enabled = false;
        tableButton.GetComponent<Image>().enabled = false;
        clearTableButton.GetComponent<Image>().enabled = false;
        addButtonImage.enabled = false;
        tableButtonImage.enabled = false;
        clearTableButtonImage.enabled = false;
        inputArea.SetActive(false);


        taskText.text = ++numberOfTask + ". " + "Включите установку.\n Примечание: воспользуйтесь тригером на элементе \"Источник питания\".";

        EventManager.Switch += WorkingControl;
        EventManager.ColorChanger += ColorControl;

        EventManager.Switch += Task1;
        EventManager.SwitchMagn += Task3;

    }

    void WorkingControl(bool work)//постоянно отслеживаем включена ли установка
    {
        isWorking = work;
    }

    void ColorControl(Color color)
    {
        currentColor = color;
        nameOfColor.text = "Текущий цвет - " + NameOfColor(currentColor);
    }

    string NameOfColor(Color color)
    {
        if (color == Color.green)
        {
            return "<color=#008000ff><b>зелёный</b></color>";
        }
        
        else
        {
            return "<color=#ffa500ff><b>жёлтый</b></color>";
        }
    }

    //введение
    void Task1(bool w)
    {
        if (w)
        {
            EventManager.Switch -= Task1;
            taskText.text = ++numberOfTask + ". " + "Установите <color=#ffa500ff><b>желтый</b></color> светодиод" + "\n"+ "Примечание: воспользуйтесь тригером на элементе \"Спектральная щель\".";
            EventManager.ColorChanger += Task2;
            Open();
        }
    }

    void Task2(Color color)
    {
        if (color == Color.yellow)
        {
            EventManager.ColorChanger -= Task2;
            taskText.text = ++numberOfTask + ". " + "Уберити Линзу с оптической скомьи" + "\n" + "Примечание: нажмите на элемент \"Линза\".";
            EventManager.SwitchMagn += Task3;
            trigerMagnifier = true;
            currentColor = color;
            Open();
        }
    }

    void Task3(bool MagnifierOn)
    {
        if (!MagnifierOn && trigerMagnifier)
        {
            EventManager.SwitchMagn -= Task3;
            taskText.text = "4. " + "Посмотрите в окуляр микроскопа" + "\n" + "Примечание: нажмите на окуляр на элементе \"Остчетный микроскоп\".";
            EventManager.SwitchCan += Task4;
            Open();
        }
    }
    void Task4(bool mainView)
    {
        if (!mainView && isWorking)
        {
            EventManager.SwitchCan -= Task4;
            taskText.text = "5. " + "Определите расстояние между центрами соседних интерференционных полос." + "\n"+ "Пимечание: Для этого необходимо измерить в малых делениях шкалы окулярного микрометра отсчетного микроскопа расстояние между серединами двух желтых полос, достаточно удаленных друг от друга, и разделить это число N на число п темных полос, находящихся между выбранными полосами. (значение N / n занести в таблицу).";
            EventManager.WritingValue += Task5;
            Open();
        }
    }

    //зеленый свет
    bool Task4()
    {
        if (TaskControl(Color.yellow))
        {
            EventManager.WritingValue -= Task4;
            taskText.text = ++numberOfTask + ". " + "Впишите в таблицу радиус второго кольца в малых делениях при <color=#008000ff><b>зелёном</b></color> свете";
            EventManager.WritingValue += Task5;
            Open();
            return true;
        }
        else return false;
    }

    bool Task5()
    {
        if (TaskControl(Color.yellow))
        {
            EventManager.WritingValue -= Task5;
            taskText.text = ++numberOfTask + ". " + "Впишите в таблицу диметр третьего кольца в малых деления при <color=#008000ff><b>зелёном</b></color> светех";
            EventManager.WritingValue += Task6;
            Open(); return true;
        }
        else return false;
    }

    bool Task6()
    {
        if (TaskControl(Color.yellow))
        {
            EventManager.WritingValue -= Task6;
            taskText.text = ++numberOfTask + ". " + "Значение радиуса кривизны линзы можно увидеть в таблице, теперь включите <color=#ffa500ff><b>жёлтый</b></color> свет";
            EventManager.ColorChanger += Task7;
            Open();
            return true;
        }
        else return false;
    }

    //желтый свет
    void Task7(Color color)
    {
        if (color == Color.yellow)
        {
            EventManager.ColorChanger -= Task7;
            taskText.text = ++numberOfTask + ". " + "Впишите в таблицу радиуса первого кольца в малых делениях при <color=#ffa500ff><b>жёлтом</b></color> свете";
            EventManager.WritingValue += Task8;
            Open();
        }
    }

    bool Task8()
    {
        if (TaskControl(Color.yellow))
        {
            EventManager.WritingValue -= Task8;
            taskText.text = ++numberOfTask + ". " + "Впишите в таблицу радиус второго кольца в малых делениях при <color=#ffa500ff><b>жёлтом</b></color> свете";
            EventManager.WritingValue += Task9;
            Open(); return true;
        }
        else return false;
    }

    bool Task9()
    {
        if (TaskControl(Color.yellow))
        {
            EventManager.WritingValue -= Task9;
            taskText.text = ++numberOfTask + ". " + "Впишите в таблицу радиус третьего кольца в малых делениях при <color=#ffa500ff><b>жёлтом</b></color> свете";
            EventManager.WritingValue += Task10;
            Open();
            return true;
        }
        else return false;
    }

    bool Task10()
    {
        if (TaskControl(Color.yellow))
        {

            EventManager.WritingValue -= Task10;
            taskText.text = ++numberOfTask + ". " + "Включите <color=#ff0000ff><b>красный</b></color> свет";
            EventManager.ColorChanger += Task11;
            Open();
            return true;
        }
        else return false;
    }

    //красный цвет
    void Task11(Color color)
    {
        if (color == Color.red)
        {
            EventManager.ColorChanger -= Task11;
            taskText.text = ++numberOfTask + ". " + "Впишите в таблицу радиус первого кольца в малых делениях при <color=#ff0000ff><b>красном</b></color> свете";
            EventManager.WritingValue += Task12;
            Open();
        }
    }

    bool Task12()
    {
        if (TaskControl(Color.red))
        {
            EventManager.WritingValue -= Task12;
            taskText.text = ++numberOfTask + ". " + "Впишите в таблицу радиус второго кольца в малых делениях при <color=#ff0000ff><b>красном</b></color> свете";
            EventManager.WritingValue += Task13;
            Open();
            return true;
        }
        else return false;
    }

    bool Task13()
    {
        if (TaskControl(Color.red))
        {

            EventManager.WritingValue -= Task13;
            taskText.text = ++numberOfTask + ". " + "Впишите в таблицу радиус третьего кольца в малых делениях при <color=#ff0000ff><b>красном</b></color> свете";
            EventManager.WritingValue += Task14;
            Open();
            return true;
        }
        else return false;
    }

    bool Task14()
    {
        if (TaskControl(Color.red))
        {

            EventManager.WritingValue -= Task14;
            taskText.text = ++numberOfTask + ". " + "Включите <color=#0000ffff><b>синий</b></color> свет";
            EventManager.ColorChanger += Task15;
            Open();
            return true;
        }
        else return false;
    }

    //синий цвет
    void Task15(Color color)
    {
        if (TaskControl(Color.blue))
        {
            EventManager.ColorChanger -= Task15;
            taskText.text = ++numberOfTask + ". " + "Впишите в таблицу радиус первого кольца в малых делениях при <color=#0000ffff><b>синем</b></color> свете";
            EventManager.WritingValue += Task16;
            Open();
        }
    }

    bool Task16()
    {
        if (TaskControl(Color.blue))
        {
            EventManager.WritingValue -= Task16;
            taskText.text = ++numberOfTask + ". " + "Впишите в таблицу радиус второго кольца в малых делениях при <color=#0000ffff><b>синем</b></color> свете";
            EventManager.WritingValue += Task17;
            Open();
            return true;
        }
        else return false;
    }

    bool Task17()
    {
        if (TaskControl(Color.blue))
        {
            EventManager.WritingValue -= Task17;
            taskText.text = ++numberOfTask + ". " + "Впишите в таблицу радиус третьего кольца в малых делениях при <color=#0000ffff><b>синем</b></color> свете";
            EventManager.WritingValue += Task18;
            Open();
            return true;
        }
        else return false;
    }

    bool Task18()
    {
        if (TaskControl(Color.blue))
        {
            EventManager.WritingValue -= Task18;
            taskText.text = ++numberOfTask + ". " + "Отлично, все измерения сняты. Теперь ознакомтесь с результатами измерений в таблице и проведите их анализ, а также подготовьте выводы в соответствии с целью работы.";
            Open();
            return true;
        }
        else return false;
    }

    bool TaskControl(Color color)
    {
        if (!isWorking)
        {
            string temporaryText = "";
            if (!wasTaskControl)
            {
                temporaryText = taskText.text;
                temporaryText = temporaryText.ToLower();
                temporaryText = temporaryText.Substring(3);
                wasTaskControl = true;
            }

            taskText.text = "<color=00ffffff>Включите установку, а затем " + temporaryText + "</color>";
            return false;
        }

        else if (color != null)
        {
            if (color == currentColor)
            {
                wasTaskControl = false;
                return true;
            }
            else
            {
                string temporaryText = "";
                if (!wasTaskControl)
                {
                    temporaryText = taskText.text;
                    temporaryText = temporaryText.ToLower();
                    temporaryText = temporaryText.Substring(3);
                    wasTaskControl = true;
                    taskText.text = "Включите " + NameOfColor(color) + " свет и " + temporaryText;
                }

                return false;
            }
        }

        else
        {
            wasTaskControl = false;
            return true;
        }
    }


    public void Open()
    {
        myimage.enabled = true;
        taskText.enabled = true;
        nameOfColor.enabled = true;
        addButton.GetComponent<Image>().enabled = true;
        tableButton.GetComponent<Image>().enabled = true;
        clearTableButton.GetComponent<Image>().enabled = true;
        addButtonImage.enabled = true;
        tableButtonImage.enabled = true;
        clearTableButtonImage.enabled = true;
        inputArea.SetActive(true);
    }

    public void Close()
    {
        myimage.enabled = false;
        taskText.enabled = false;
        nameOfColor.enabled = false;
        addButton.GetComponent<Image>().enabled = false;
        tableButton.GetComponent<Image>().enabled = false;
        clearTableButton.GetComponent<Image>().enabled = false;
        addButtonImage.enabled = false;
        tableButtonImage.enabled = false;
        clearTableButtonImage.enabled = false;
        inputArea.SetActive(false);
    }
    public void ResetTasks()
    {
        EventManager.SwitchWork(false);
        numberOfTask = 0;
        taskText.text = ++numberOfTask + ". " + "Включите установку";
        EventManager.Switch += Task1;
    }

}

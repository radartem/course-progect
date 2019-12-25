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
            taskText.text = "2. " + "Установите <color=#ffa500ff><b>желтый</b></color> светодиод" + "\n"+ "Примечание: воспользуйтесь тригером на элементе \"Спектральная щель\".";
            EventManager.ColorChanger += Task2;
            Open();
        }
    }

    void Task2(Color color)
    {
        if (color == Color.yellow)
        {
            EventManager.ColorChanger -= Task2;
            taskText.text = "3. " + "Уберити Линзу с оптической скомьи" + "\n" + "Примечание: нажмите на элемент \"Линза\".";
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
            taskText.text = "5. <b>(1 из 3)</b>" + "Определите расстояние между центрами соседних интерференционных полос." + "\n"+ "Пимечание: Для этого необходимо измерить в малых делениях шкалы окулярного микрометра отсчетного микроскопа расстояние между серединами двух желтых полос, достаточно удаленных друг от друга, и разделить это число N на число п темных полос, находящихся между выбранными полосами. (значение N / n занести в таблицу).";
            EventManager.WritingValue += Task5;
            Open();
        }
    }

    bool Task5()
    {
        if (TaskControl(Color.yellow))
        {
            EventManager.WritingValue -= Task5;
            taskText.text = "5. <b>(2 из 3)</b>" + "Определите расстояние между центрами соседних интерференционных полос." + "\n" + "Пимечание: Для этого необходимо измерить в малых делениях шкалы окулярного микрометра отсчетного микроскопа расстояние между серединами двух желтых полос, достаточно удаленных друг от друга, и разделить это число N на число п темных полос, находящихся между выбранными полосами. (значение N / n занести в таблицу).";
            EventManager.WritingValue += Task6;
            Open();
            return true;
        }
        else return false;
    }
    bool Task6()
    {
        if (TaskControl(Color.yellow))
        {
            EventManager.WritingValue -= Task6;
            taskText.text = "5. <b>(3 из 3)</b>" + "Определите расстояние между центрами соседних интерференционных полос." + "\n" + "Пимечание: Для этого необходимо измерить в малых делениях шкалы окулярного микрометра отсчетного микроскопа расстояние между серединами двух желтых полос, достаточно удаленных друг от друга, и разделить это число N на число п темных полос, находящихся между выбранными полосами. (значение N / n занести в таблицу).";
            EventManager.WritingValue += Task7;
            Open();
            return true;
        }
        else return false;
    }

    //зеленый свет
    bool Task7()
    {
        if (TaskControl(Color.yellow))
        {
            EventManager.WritingValue -= Task7;
            taskText.text = "6. " + "Верните Линзу на оптическую скомью" + "\n" + "Примечание: нажмите на элемент \"Линза\".";
            EventManager.SwitchMagn += Task8;
            trigerMagnifier = true;
            Open();
            return true;
        }
        else return false;
    }

    void Task8(bool MagnifierOn)
    {
        if (MagnifierOn && trigerMagnifier)
        {
            EventManager.SwitchMagn -= Task8;
            taskText.text = "7. " + "Посмотрите в окуляр микроскопа" + "\n" + "Примечание: нажмите на окуляр на элементе \"Остчетный микроскоп\".";
            EventManager.SwitchCan += Task9;
            Open();
        }
    }



    void Task9(bool mainView)
    {
        if (!mainView && isWorking)
        {
            EventManager.SwitchCan -= Task9;
            taskText.text = "8. " + "Измерьте в малых делениях шкалы окулярного микрометра отсчетного микроскопа расстояние z между серединами мнимых когерентных источников света. (значение Z занести в таблицу).";
            EventManager.WritingValue += Task10;
            Open();
        }
    }
    bool Task10()
    {
        if (TaskControl(Color.yellow))
        {
            EventManager.WritingValue -= Task10;
            taskText.text = "9. " + "Установите <color=#008000ff><b>зеленый</b></color> светодиод" + "\n" + "Примечание: воспользуйтесь тригером на элементе \"Спектральная щель\".";
            EventManager.ColorChanger += Task11;
            Open();
            return true;
        }
        return false;
    }

    void Task11(Color color)
    {
        if (color == Color.green)
        {
            EventManager.ColorChanger -= Task11;
            taskText.text = "10. " + "Уберити Линзу с оптической скомьи" + "\n" + "Примечание: нажмите на элемент \"Линза\".";
            EventManager.SwitchMagn += Task12;
            trigerMagnifier = true;
            currentColor = color;
            Open();
        }
    }

    void Task12(bool MagnifierOn)
    {
        if (!MagnifierOn && trigerMagnifier)
        {
            EventManager.SwitchMagn -= Task12;
            taskText.text = "11. " + "Посмотрите в окуляр микроскопа" + "\n" + "Примечание: нажмите на окуляр на элементе \"Остчетный микроскоп\".";
            EventManager.SwitchCan += Task13;
            Open();
        }
    }
    void Task13(bool mainView)
    {
        if (!mainView && isWorking)
        {
            EventManager.SwitchCan -= Task13;
            taskText.text = "12. <b>(1 из 3)</b>" + "Определите расстояние между центрами соседних интерференционных полос." + "\n" + "Пимечание: Для этого необходимо измерить в малых делениях шкалы окулярного микрометра отсчетного микроскопа расстояние между серединами двух желтых полос, достаточно удаленных друг от друга, и разделить это число N на число п темных полос, находящихся между выбранными полосами. (значение N / n занести в таблицу).";
            EventManager.WritingValue += Task14;
            Open();
        }
    }

    bool Task14()
    {
        if (TaskControl(Color.green))
        {
            EventManager.WritingValue -= Task14;
            taskText.text = "12. <b>(2 из 3)</b>" + "Определите расстояние между центрами соседних интерференционных полос." + "\n" + "Пимечание: Для этого необходимо измерить в малых делениях шкалы окулярного микрометра отсчетного микроскопа расстояние между серединами двух желтых полос, достаточно удаленных друг от друга, и разделить это число N на число п темных полос, находящихся между выбранными полосами. (значение N / n занести в таблицу).";
            EventManager.WritingValue += Task15;
            Open();
            return true;
        }
        else return false;
    }
    bool Task15()
    {
        if (TaskControl(Color.green))
        {
            EventManager.WritingValue -= Task15;
            taskText.text = "12. <b>(3 из 3)</b>" + "Определите расстояние между центрами соседних интерференционных полос." + "\n" + "Пимечание: Для этого необходимо измерить в малых делениях шкалы окулярного микрометра отсчетного микроскопа расстояние между серединами двух желтых полос, достаточно удаленных друг от друга, и разделить это число N на число п темных полос, находящихся между выбранными полосами. (значение N / n занести в таблицу).";
            EventManager.WritingValue += Task16;
            Open();
            return true;
        }
        else return false;
    }

    //зеленый свет
    bool Task16()
    {
        if (TaskControl(Color.green))
        {
            EventManager.WritingValue -= Task16;
            taskText.text = "13. " + "Верните Линзу на оптическую скомью" + "\n" + "Примечание: нажмите на элемент \"Линза\".";
            EventManager.SwitchMagn += Task17;
            trigerMagnifier = true;
            Open();
            return true;
        }
        else return false;
    }

    void Task17(bool MagnifierOn)
    {
        if (MagnifierOn && trigerMagnifier)
        {
            EventManager.SwitchMagn -= Task17;
            taskText.text = "14. " + "Посмотрите в окуляр микроскопа" + "\n" + "Примечание: нажмите на окуляр на элементе \"Остчетный микроскоп\".";
            EventManager.SwitchCan += Task18;
            Open();
        }
    }



    void Task18(bool mainView)
    {
        if (!mainView && isWorking)
        {
            EventManager.SwitchCan -= Task18;
            taskText.text = "15. " + "Измерьте в малых делениях шкалы окулярного микрометра отсчетного микроскопа расстояние z между серединами мнимых когерентных источников света. (значение Z занести в таблицу).";
            EventManager.WritingValue += Task19;
            Open();
        }
    }
    bool Task19()
    {
        if (TaskControl(Color.green))
        {
            EventManager.WritingValue -= Task19;
            taskText.text = "16. " + "Отлично, все измерения сняты. Теперь ознакомтесь с результатами измерений в таблице и проведите их анализ, а также подготовьте выводы в соответствии с целью работы.";
            Open();
            return true;
        }
        else return false;
    }

    static int counter=0;
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
        taskText.text = "1. " + "Включите установку";
        EventManager.Switch += Task1;
    }

}

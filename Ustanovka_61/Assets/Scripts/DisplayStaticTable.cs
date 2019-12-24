using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayStaticTable : MonoBehaviour
{
    [SerializeField]
    GameObject table;
    void Start()
    {
        state = State.NonActiv;
        //table.SetActive(false);
    }
    enum State
    {
        Active,
        NonActiv
    }
    // Update is called once per frame
    State state;

    private void OnMouseDown()
    {
        switch (state)
        {

            case State.NonActiv:
                {
                    table.SetActive(true);

                    state = State.Active;
                }
                break;
            case State.Active:
                {
                    table.SetActive(false);

                    state = State.NonActiv;
                }
                break;
        }

    }
}

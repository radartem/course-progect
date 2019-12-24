using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class click : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        state = State.OnBench;
    }
    enum State
    {
        OnTable,
        OnBench
    }
    // Update is called once per frame
    State state;

    private void OnMouseDown()
    {
        switch (state)
        {
            case State.OnBench:
                {
                    StartCoroutine(PutOnTable());

                    state = State.OnTable;
                }
                break;
            case State.OnTable:
                {
                    StartCoroutine(PutOnBench());

                    state = State.OnBench;
                }
                break;
        }

    }
    IEnumerator Up()
    {
        for (float i = 0f; i < 5; i += 1)
        {
            transform.position += new Vector3(0, 0.5f, 0);
            yield return new WaitForSeconds(0.05f);
        }
    }
    IEnumerator Down()
    {
        for (float i = 0f; i < 5; i += 1)
        {
            transform.position += new Vector3(0, -0.5f, 0);
            yield return new WaitForSeconds(0.05f);
        }
    }
    IEnumerator PutOnTable()
    {
        for (int j = 0; j < 3; j++)
        {
            switch(j)
            {
                case 0:
                    for (float i = 0f; i < 5; i += 1)
                    {
                        transform.position += new Vector3(0, 0.25f, 0);
                        yield return new WaitForSeconds(0.05f);
                    }
                    break;
                case 1:
                    for (float i = 0f; i < 10; i += 1)
                    {
                        transform.position += new Vector3(0, -0.25f, 0.5f);
                        transform.Rotate(new Vector3(0, 9, 0));

                        yield return new WaitForSeconds(0.05f);
                    }
                    break;
                case 2:
                    for (float i = 0f; i < 5; i += 1)
                    {
                        transform.position += new Vector3(0, -0.25f, 0);
                        yield return new WaitForSeconds(0.05f);
                    }
                    break;
            }
        }
    }
    IEnumerator PutOnBench()
    {
        for (int j = 0; j < 3; j++)
        {
            switch (j)
            {
                case 0:
                    for (float i = 0f; i < 5; i += 1)
                    {
                        transform.position += new Vector3(0, 0.25f, 0);
                        yield return new WaitForSeconds(0.05f);
                    }
                    break;
                case 1:
                    for (float i = 0f; i < 10; i += 1)
                    {
                        transform.position += new Vector3(0, +0.25f, -0.5f);
                        transform.Rotate(new Vector3(0, -9, 0));

                        yield return new WaitForSeconds(0.05f);
                    }
                    break;
                case 2:
                    for (float i = 0f; i < 5; i += 1)
                    {
                        transform.position += new Vector3(0, -0.25f, 0);
                        yield return new WaitForSeconds(0.05f);
                    }
                    break;
            }
        }
    }
}

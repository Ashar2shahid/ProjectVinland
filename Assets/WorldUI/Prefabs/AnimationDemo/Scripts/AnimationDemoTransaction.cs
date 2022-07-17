using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDemoTransaction : MonoBehaviour
{
    private const int V = 1;
    [SerializeField] private GameObject OK;
    [SerializeField] private GameObject FAIL;
    [SerializeField] private GameObject main;
    [SerializeField] private GameObject c1;
    [SerializeField] private GameObject c2;
    [SerializeField] private GameObject c3;
    [SerializeField] private GameObject c4;
    [SerializeField] private GameObject c5;
    [SerializeField] private GameObject c6;
    int x = 0;
    public void ok()
    {
        OK.gameObject.SetActive(true);
        FAIL.gameObject.SetActive(false);
        main.gameObject.SetActive(false);
        off();

    }
    public void fail()
    {
        OK.gameObject.SetActive(false);
        FAIL.gameObject.SetActive(true);
        main.gameObject.SetActive(false);
        off();

    }
    public void next()
    {

        OK.gameObject.SetActive(false);
        FAIL.gameObject.SetActive(false);
        main.gameObject.SetActive(true);
        switch (x)
        {
            case 0:
                off();
                c1.gameObject.SetActive(true);
                x++;
                break;
            case 1:
                c1.gameObject.SetActive(false);
                c2.gameObject.SetActive(true);
                x++;
                break;
            case 2:
                c2.gameObject.SetActive(false);
                c3.gameObject.SetActive(true);
                x++;
                break;
            case 3:
                c3.gameObject.SetActive(false);
                c4.gameObject.SetActive(true);
                x++;
                break;
            case 4:
                c4.gameObject.SetActive(false);
                c5.gameObject.SetActive(true);
                x++;
                break;
            case 5:
                c5.gameObject.SetActive(false);
                c6.gameObject.SetActive(true);
                x = 0 ;
                break;
        }
    }

    public void off()
    {
        c1.gameObject.SetActive(false);
        c2.gameObject.SetActive(false);
        c3.gameObject.SetActive(false);
        c4.gameObject.SetActive(false);
        c5.gameObject.SetActive(false);
        c6.gameObject.SetActive(false);
    }
}

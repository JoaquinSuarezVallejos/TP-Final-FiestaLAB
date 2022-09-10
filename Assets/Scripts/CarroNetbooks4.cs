﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarroNetbooks4 : MonoBehaviour
{
    public GameObject inticon, Ntext;
    public static bool check;

    void Start()
    {
        check = false;
    }   

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inticon.SetActive(true);
            Ntext.SetActive(true);

            if (Input.GetKeyDown(KeyCode.N))
            {
                check = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inticon.SetActive(false);
            Ntext.SetActive(false);
            check = false;
        }
    }
}

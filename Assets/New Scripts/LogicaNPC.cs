using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using TMPro;

public class LogicaNPC : MonoBehaviour
{
    public GameObject panelNPCHablar, panelNPCMision, btnSiguiente, inticon, EText, Player;
    public TextMeshProUGUI textoMision;
    public GameObject[] objetivos;
    public int numDeObjetivos;

    void Start()
    {
        numDeObjetivos = objetivos.Length;
        textoMision.text = "Consigue  todos  los  objetos  para  armar  una  fiesta " + "\n Restantes: " + numDeObjetivos;
        panelNPCHablar.SetActive(false);
    }

    void OnTriggerEnter (Collider col)
    {
        if (col.gameObject.tag == "NPC")
        {
            inticon.SetActive(true);
            EText.SetActive(true);
        }
    }

    void OnTriggerStay (Collider col)
    {
        if (col.gameObject.tag == "NPC") 
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player.GetComponent<FirstPersonController>().enabled = false;
                inticon.SetActive(false);
                EText.SetActive(false);
            }
        }
    }

    void OnTriggerExit (Collider col)
    {
        if (col.gameObject.tag == "NPC")
        {
            inticon.SetActive(false);
            EText.SetActive(false);
        }
    }
}
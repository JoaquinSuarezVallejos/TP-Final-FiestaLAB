using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using TMPro;

public class LogicaNPC : MonoBehaviour
{
    public GameObject panelNPCHablar, panelNPCMision, inticon, Player, MissionObjects, PanelGeneral;
    public TextMeshProUGUI textoObjetivoNPC;
    public GameObject[] objetivos;
    public int numDeObjetivos;
    public AudioSource HmmNPC;
    public bool check = false;
    public static bool check2 = false;

    void Start()
    {
        numDeObjetivos = objetivos.Length;
        panelNPCHablar.SetActive(false);
        check = false;
        check2 = false;
    }

    void OnTriggerEnter (Collider col)
    {
        if (check == false)
        {
            if (col.gameObject.tag == "NPC")
            {
                inticon.SetActive(true);
                panelNPCHablar.SetActive(true);
            }
        }
    }

    void OnTriggerStay (Collider col)
    {
        if (col.gameObject.tag == "NPC") 
        {
            if (check == false)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    HmmNPC.Play();
                    Player.GetComponent<FirstPersonController>().enabled = false;
                    inticon.SetActive(false);
                    panelNPCHablar.SetActive(false);
                    panelNPCMision.SetActive(true);
                    StartCoroutine(HablarConNPC());
                    check = true;
                }
            }
        }
    }

    void OnTriggerExit (Collider col)
    {
        if (col.gameObject.tag == "NPC")
        {
            inticon.SetActive(false);
            panelNPCHablar.SetActive(false);
        }
    }

    IEnumerator HablarConNPC()
    {
        textoObjetivoNPC.text = "Michelle:  Que  laboratorios  tan  aburridos!";
        yield return new WaitForSeconds(2.5f);
        textoObjetivoNPC.text = "Michelle:  Si  tan  solo  se  hiciera  una  fiesta...";
        yield return new WaitForSeconds(2.5f);
        textoObjetivoNPC.text = "Michelle:  Crees  que  se  pueda?";
        yield return new WaitForSeconds(2.5f);
        textoObjetivoNPC.text = "Michelle:  Genial, manos a  la  obra!";
        yield return new WaitForSeconds(2.5f);
        panelNPCMision.SetActive(false);
        Player.GetComponent<FirstPersonController>().enabled = true;
        MissionObjects.SetActive(true);
        PanelGeneral.SetActive(true);
        check2 = true;
    }
}
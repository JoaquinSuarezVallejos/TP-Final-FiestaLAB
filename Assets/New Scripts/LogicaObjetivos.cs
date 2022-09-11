using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LogicaObjetivos : MonoBehaviour
{
    [SerializeField] int[] numDeObjetivos = new int[13];
    [SerializeField] TextMeshProUGUI textoMision;
    [SerializeField] GameObject inticon, EText;
    [SerializeField] int cantidadObjetivos;

    void Update()
    {
        if (LogicaNPC.check2 == true)
        {
            cantidadObjetivos = numDeObjetivos.Length;
            cantidadObjetivos = GameObject.FindGameObjectsWithTag("Objetivo").Length;
            textoMision.text = "Consigue  todos  los  objetos  para  armar  una  fiesta " + "\n Restantes: " + cantidadObjetivos;
            LogicaNPC.check2 = false;
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Objetivo")
        {
            inticon.SetActive(true);
            EText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                Destroy(col.transform.gameObject);
                cantidadObjetivos--;
                textoMision.text = "Consigue  todos  los  objetos  para  armar  una  fiesta " + "\n Restantes: " + cantidadObjetivos;

                inticon.SetActive(false);
                EText.SetActive(false);
            }

            if (cantidadObjetivos <= 0)
            {
                textoMision.text = "Regresa con el NPC";
            }
        }
   }

   void OnTriggerExit(Collider col)
   {
        if (col.gameObject.tag == "Objetivo")
        {
            inticon.SetActive(false);
            EText.SetActive(false);
        }
   }
}

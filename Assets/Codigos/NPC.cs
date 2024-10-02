using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public GameObject panelDialogo;
    public Text textoDialogo;
    public string[] dialogo;
    private int index;

    public GameObject boton;
    public float velocidadTexto;
    public bool distanciaJugador;

    // Update is called once per frame
    void Start()
    {
        panelDialogo.SetActive(false);
    }
    
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && distanciaJugador)
        {
            if(panelDialogo.activeInHierarchy)
            {
                ceroTexto();
            }
            else
            {
                panelDialogo.SetActive(true); 
                StartCoroutine(Escritura());

            }

        }  

        if(textoDialogo.text == dialogo[index])
        {
            boton.SetActive(true);
        } 

    }


    public void ceroTexto()
    {
        textoDialogo.text = "";
        index = 0;
        panelDialogo.SetActive(false);
    }


    IEnumerator Escritura()
    {
        foreach(char letter in dialogo[index].ToCharArray())
        {
            textoDialogo.text += letter;
            yield return new WaitForSeconds(velocidadTexto);
        }
    }

    public void sigLinea()
    {
        if(index == dialogo.Length - 1){
            boton.SetActive(false);
        }
        if(index < dialogo.Length - 1)
        {
            index++;
            textoDialogo.text = " ";
            StartCoroutine(Escritura());
        }
        else
        {
            ceroTexto();
        }
    }


    private void OnTriggerEnter2D(Collider2D otro)
    {
        if(otro.CompareTag("Player"))
        {
            distanciaJugador = true;

        }
    }

    private void OnTriggerExit2D(Collider2D otro)
    {
        if(otro.CompareTag("Player"))
        {
            distanciaJugador = false;
            ceroTexto();

        }
    }
}

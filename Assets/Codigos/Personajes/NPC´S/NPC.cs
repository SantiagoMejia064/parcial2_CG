using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject panelDialogo;  // Panel de diálogo
    public Text textoDialogo;        // Texto del diálogo
    public string[] dialogo;         // Primer conjunto de diálogos
    private int index;

    public GameObject boton;         // Botón de continuar
    public float velocidadTexto;     // Velocidad de escritura
    public bool distanciaJugador;    // Verifica si el jugador está cerca del NPC

    public GameObject objetoRequerido;  // Referencia al objeto que el jugador debe recoger

    public string[] segundoDialogo;  // Segundo conjunto de diálogos

    private bool primerDialogoTerminado = false;  // Saber si el primer diálogo ha terminado
    private bool puedeMostrarSegundoDialogo = false;  // Saber si puede activar el segundo diálogo

    void Start()
    {
        panelDialogo.SetActive(false); // Asegúrate de que el panel de diálogo esté desactivado al principio
        boton.SetActive(false);        // Desactiva el botón de continuar al inicio
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && distanciaJugador)
        {
            if (panelDialogo.activeInHierarchy)
            {
                ceroTexto();  // Si el diálogo está activo, lo cierra
            }
            else
            {
                if (!primerDialogoTerminado)
                {
                    panelDialogo.SetActive(true);
                    StartCoroutine(Escritura());
                }
                else if (puedeMostrarSegundoDialogo)
                {
                    panelDialogo.SetActive(true);  // Activa el segundo diálogo solo si el objeto ha sido recogido
                    MostrarSegundoDialogo();
                }
            }
        }

        // Solo activar el botón si el diálogo está completo
        if (textoDialogo.text == dialogo[index])
        {
            boton.SetActive(true);
        }
    }

    // Limpia el texto y reinicia el diálogo
    public void ceroTexto()
    {
        textoDialogo.text = "";
        index = 0;
        panelDialogo.SetActive(false);
    }

    // Escribe el diálogo letra por letra
    IEnumerator Escritura()
    {
        textoDialogo.text = "";  // Limpia el texto actual

        foreach (char letter in dialogo[index].ToCharArray())
        {
            textoDialogo.text += letter;
            yield return new WaitForSeconds(velocidadTexto);  // Velocidad de escritura
        }
    }

    // Avanza al siguiente diálogo o termina el primer conjunto
    public void sigLinea()
    {
        boton.SetActive(false);  // Desactiva el botón hasta que se complete la línea

        if (index < dialogo.Length - 1)
        {
            index++;
            textoDialogo.text = " ";
            StartCoroutine(Escritura());
        }
        else
        {
            // Cuando termina el primer diálogo, se cierra el panel y se espera a recoger el objeto
            primerDialogoTerminado = true;
            ceroTexto();
        }
    }

    // Detecta la entrada del jugador al área de interacción
    private void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Player"))
        {
            distanciaJugador = true;
            Debug.Log("Tiene " + gameManager.cantLlaveMorada + " llaves moradas");
        }

        // Detecta si el jugador ha recogido el objeto
        if (gameManager.cantLlaveMorada > 0)
        {
            puedeMostrarSegundoDialogo = true;
        }
    }

    // Detecta cuando el jugador sale del área de interacción
    private void OnTriggerExit2D(Collider2D otro)
    {
        if (otro.CompareTag("Player"))
        {
            distanciaJugador = false;
            ceroTexto();
        }
    }

    // Muestra el segundo diálogo después de recoger el objeto
    void MostrarSegundoDialogo()
    {
        dialogo = segundoDialogo;  // Cambia al segundo conjunto de diálogos
        index = 0;                 // Reinicia el índice
        StartCoroutine(Escritura());   // Comienza a escribir el segundo diálogo
    }
}

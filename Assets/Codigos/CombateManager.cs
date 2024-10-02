using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateManager : MonoBehaviour
{
   
    // Referencias a los GameObjects de cada personaje (P1, P2, P3, P4)
    public GameObject personaje1;
    public GameObject personaje2;
    public GameObject personaje3;
    public GameObject personaje4;

    // Referencia al panel de selección de personajes
    public GameObject panelSeleccionPersonajes;

    // Método que selecciona el personaje basado en el índice (del botón presionado)
    public void SeleccionarPersonaje(int indice)
    {
        // Desactivar todos los personajes primero
        personaje1.SetActive(false);
        personaje2.SetActive(false);
        personaje3.SetActive(false);
        personaje4.SetActive(false);

        // Activar el personaje seleccionado
        switch (indice)
        {
            case 1:
                personaje1.SetActive(true);
                break;
            case 2:
                personaje2.SetActive(true);
                break;
            case 3:
                personaje3.SetActive(true);
                break;
            case 4:
                personaje4.SetActive(true);
                break;
            default:
                Debug.LogWarning("Índice de personaje inválido");
                break;
        }

        // Desactivar el panel de selección después de elegir un personaje
        panelSeleccionPersonajes.SetActive(false);
    }
}

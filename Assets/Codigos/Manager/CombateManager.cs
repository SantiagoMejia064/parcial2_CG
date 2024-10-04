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
    public GameObject P1Attack1;
    public GameObject P1Attack2;
    public GameObject P2Attack1;
    public GameObject P2Attack2;
    public GameObject P2Attack3;
    public GameObject P3Attack1;
    public GameObject P4Attack1;
    public GameObject enemigo1;
    public GameObject enemigo2;
    public GameObject enemigo3;
    public GameObject enemigo4;
    public bool playerAttacking;
    public bool enemyAttacking;
    //public GameManager gameManager;

    // Referencia al panel de selecci�n de personajes
    public GameObject panelSeleccionPersonajes;

    void Awake(){
        if(GameManager.Instance != null)
        {
            switch(GameManager.Instance.enemigoEnColision){
            case 1:
                enemigo1.SetActive(true);
                break;
            case 2:
                enemigo2.SetActive(true);
                break;
            case 3:
                enemigo3.SetActive(true);
                break;
            case 4:
                enemigo4.SetActive(true);
                break;
            default:
                Debug.LogWarning("indice de enemigo invalido");
                break;

            }
        }
        //Debug.Log("Colisionó con enemigo #" + gameManager.enemigoEnColision);
    }

    // M�todo que selecciona el personaje basado en el �ndice (del bot�n presionado)
    public void SeleccionarPersonaje(int indice)
    {
        // Desactivar todos los personajes primero
        personaje1.SetActive(false);
        personaje2.SetActive(false);
        personaje3.SetActive(false);
        personaje4.SetActive(false);
        P1Attack1.SetActive(false);
        P1Attack2.SetActive(false);
        P2Attack1.SetActive(false);
        P2Attack2.SetActive(false);
        P2Attack3.SetActive(false);
        P3Attack1.SetActive(false);
        P4Attack1.SetActive(false);
        

        // Activar el personaje seleccionado
        switch (indice)
        {
            case 1:
                personaje1.SetActive(true);
                P1Attack1.SetActive(true);
                P1Attack2.SetActive(true);
                break;
            case 2:
                personaje2.SetActive(true);
                P2Attack1.SetActive(true);
                P2Attack2.SetActive(true);
                P2Attack3.SetActive(true);
                break;
            case 3:
                personaje3.SetActive(true);
                P3Attack1.SetActive(true);
                break;
            case 4:
                personaje4.SetActive(true);
                P4Attack1.SetActive(true);
                break;
            default:
                Debug.LogWarning("indice de personaje invalido");
                break;
        }

        // Desactivar el panel de selecci�n despu�s de elegir un personaje
        panelSeleccionPersonajes.SetActive(false);
    }

    public void eleccionAtaque(){
        if(playerAttacking){
            Debug.Log("Ataque del jugador");
            P1Attack1.SetActive(false);
            P1Attack2.SetActive(false);
            P2Attack1.SetActive(false);
            P2Attack2.SetActive(false);
            P2Attack3.SetActive(false);
            P3Attack1.SetActive(false);
            P4Attack1.SetActive(false);
        }else if(enemyAttacking){
            Debug.Log("Ataque del enemigo");
        }
    }
}
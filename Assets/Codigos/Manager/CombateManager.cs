using System.Collections;
using System.Collections.Generic;
using System.Reflection;
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
    public Enemigo1 enemigoUNO;
    public Enemigo2 enemigoDOS;
    public Enemigo3 enemigoTRES;
    public Enemigo4 enemigoCUATRO;
    //public GameManager gameManager;

    // Referencia al panel de selecci�n de personajes
    public GameObject panelSeleccionPersonajes;


   /* private Peleador [] peleadores;
    private int peleadorindex;

    public void Start()
    {
        peleadores = new Peleador[4];
        peleadores[0] = personaje1.GetComponent<Peleador>();
        peleadores[1] = personaje2.GetComponent<Peleador>();
        peleadores[2] = personaje3.GetComponent<Peleador>();
        peleadores[3] = personaje4.GetComponent<Peleador>();
        peleadorindex = 0;
        peleadores[peleadorindex].InitTurn();
    }*/
    /*
    void Start()
    {
        //playerAttacking = true;
        //enemyAttacking = false;
        StartCoroutine(eleccionAtaque());
    }
    */

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

    IEnumerator eleccionAtaque(){
        while (true)
        {
            if (playerAttacking)
            {
                // Lógica para el turno del jugador
                Debug.Log("Turno del jugador");
                // Realiza el ataque del jugador aquí
                // Después de que el jugador termine su ataque, cambiar al turno del enemigo
                yield return new WaitForSeconds(2f);  // Espera un tiempo para simular el ataque
                playerAttacking = false;
                enemyAttacking = true;
            }
            else if (enemyAttacking)
            {
                // Lógica para el turno del enemigo
                Debug.Log("Turno del enemigo");
                
                switch(GameManager.Instance.enemigoEnColision){
                    case 1:
                        enemigoUNO.TiradaAtaque();  // El enemigo realiza su ataque
                        break;
                    case 2:
                        enemigoDOS.TiradaAtaque();  // El enemigo realiza su ataque
                        break;
                    case 3:
                        enemigoTRES.TiradaAtaque();  // El enemigo realiza su ataque
                        break;
                    case 4:
                        enemigoCUATRO.TiradaAtaque();  // El enemigo realiza su ataque
                        break;
                    default:
                        Debug.LogWarning("indice de enemigo invalido");
                        break;
                }
                

                // Después del ataque del enemigo, cambiar el turno al jugador
                yield return new WaitForSeconds(2f);  // Espera un tiempo para simular el ataque
                playerAttacking = true;
                enemyAttacking = false;
            }
        }
    }
}
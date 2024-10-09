using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CombateManager : MonoBehaviour
{
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


    public int currentPlayer;
    public int currentEnemy;



    public Button[] playerAttackButtons;  // Botones de ataque del jugador
    public GameManager gameManager;
    public GameObject panelSeleccionPersonajes;
    public GameObject panelCombate;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Combate")
        {
            playerAttacking = true; 
            enemyAttacking = false;  
            Debug.Log("Iniciando combate");
            ActivatePlayerAttackButtons(true); // Activar botones de ataque al inicio
        }
        else
        {
            playerAttacking = false;
            enemyAttacking = false;
            Debug.Log("No es la escena para que combatan");
        }

        //GameManager.Instance.vidaJugador.text = "Vida Jugador: " + Player1Attack.resistencia;  // Actualiza el texto inicial de vida del jugador
    }


    void Awake(){
        if(SceneManager.GetActiveScene().name == "Combate"){
            if(!GameManager.Instance)
            {
                switch(GameManager.Instance.enemigoEnColision){
                case 1:
                    enemigo1.SetActive(true);
                    currentEnemy = 1;
                    break;
                case 2:
                    enemigo2.SetActive(true);
                    currentEnemy = 2;
                    break;
                case 3:
                    enemigo3.SetActive(true);
                    currentEnemy = 3;
                    break;
                case 4:
                    enemigo4.SetActive(true);
                    currentEnemy = 4;
                    break;
                default:
                    Debug.LogWarning("indice de enemigo invalido");
                    break;

                }
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
                currentPlayer = 1;
                break;
            case 2:
                personaje2.SetActive(true);
                P2Attack1.SetActive(true);
                P2Attack2.SetActive(true);
                P2Attack3.SetActive(true);
                currentPlayer = 2;
                break;
            case 3:
                personaje3.SetActive(true);
                P3Attack1.SetActive(true);
                currentPlayer = 3;
                break;
            case 4:
                personaje4.SetActive(true);
                P4Attack1.SetActive(true);
                currentPlayer = 4;
                break;
            default:
                Debug.LogWarning("indice de personaje invalido");
                break;
        }

        // Desactivar el panel de selecci�n despu�s de elegir un personaje
        panelSeleccionPersonajes.SetActive(false);
        panelCombate.SetActive(true);
    }

    // Activar o desactivar los botones de ataque del jugador
    public void ActivatePlayerAttackButtons(bool state)
    {
        foreach (Button btn in playerAttackButtons)
    {
        if (btn != null) // Verificamos que el botón no sea null
        {
            btn.interactable = state; // Si state es 'true', se activan; si es 'false', se desactivan.
        }
    }
    }

    // Método para manejar el ataque del jugador cuando se presiona un botón
    /*public void PlayerAttack(int ataqueIndex)
    {
        if (playerAttacking)
        {
            Debug.Log("El jugador ha atacado.");
            ActivatePlayerAttackButtons(false); // Desactiva los botones de ataque

            // Simular el ataque basado en el índice de ataque
            if (ataqueIndex == 1)
            {
                // Ejemplo: llamar a un método de ataque 1
                P1Attack1.GetComponent<Player1Attack>().TiradaAtaque();
            }
            else if (ataqueIndex == 2)
            {
                // Ejemplo: llamar a un método de ataque 2
                P1Attack2.GetComponent<Player1Attack>().TiradaAtaque2();
            }

            // Luego de que el jugador ataque, pasa al turno del enemigo
            StartCoroutine(eleccionAtaqueEnemigo());
        }
    }*/

    // Coroutine que maneja el turno del enemigo
    public IEnumerator eleccionAtaqueEnemigo()
    {
        if (enemyAttacking)
            {
                playerAttacking = false;
                enemyAttacking = true;

                Debug.Log("Turno del enemigo comenzando en 1.5 segundos...");

                yield return new WaitForSeconds(1.5f);
                Debug.Log("Lógica de ataque del enemigo, enemigo en colisión: " + GameManager.Instance.enemigoEnColision);

                switch (GameManager.Instance.enemigoEnColision)
                {
                    case 1:
                        enemigoUNO.TiradaAtaque();
                        Debug.Log("El enemigo 1 atacó");  // El enemigo realiza su ataque
                        break;
                    case 2:
                        enemigoDOS.TiradaAtaque();
                        Debug.Log("El enemigo 2 atacó");  // El enemigo realiza su ataque
                        break;
                    case 3:
                        enemigoTRES.TiradaAtaque();
                        Debug.Log("El enemigo 3 atacó");  // El enemigo realiza su ataque
                        break;
                    case 4:
                        enemigoCUATRO.TiradaAtaque();
                        Debug.Log("El enemigo 4 atacó");  // El enemigo realiza su ataque
                        break; 
                    default:
                        Debug.LogWarning("indice de enemigo invalido");
                        break;
                }

                yield return new WaitForSeconds(2f);


                Debug.Log("Turno del enemigo terminado, activando turno del jugador...");
                playerAttacking = true;
                enemyAttacking = false;
                
                Debug.Log("Turno del mancito activate");
                ActivatePlayerAttackButtons(true);
                
            }   
            else
            {
                Debug.Log("No es el turno del enemy");
            }
            
             
        
    }
}



























    /*IEnumerator eleccionAtaque()
    {
        while (true)
    {
        if (playerAttacking)
        {
            // Lógica para el turno del jugador
            Debug.Log("Turno del jugador");
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

            yield return new WaitForSeconds(2f);  // Espera un tiempo para simular el ataque
            playerAttacking = true;
            enemyAttacking = false;
        }
    }
    }*/
    

    


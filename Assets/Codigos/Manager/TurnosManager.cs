using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnosManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] players;
    public GameObject[] enemies;
    private int currentTurnIndex = 0;  // Índice para manejar quién tiene el turno

    public bool playerAttacking = true;  // Empieza el turno con el jugador
    public bool enemyAttacking = false;

    // Para manejar las acciones de enemigos
    public Enemigo1 enemigoUNO;
    public Enemigo2 enemigoDOS;
    public Enemigo3 enemigoTRES;
    public Enemigo4 enemigoCUATRO;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Combate")
        {
            Debug.Log("Iniciando combate");
            StartTurn();  // Iniciar el primer turno
        }
        else
        {
            playerAttacking = false;
            enemyAttacking = false;
            Debug.Log("No es la escena para que estos personajes combatan");
        }
    }

    // Inicia el turno del jugador actual
    void StartTurn()
    {
        if (currentTurnIndex < players.Length)  // Turno de un jugador
        {
            Debug.Log("Turno del jugador: " + currentTurnIndex);
            playerAttacking = true;
            enemyAttacking = false;
        }
        else if (currentTurnIndex < players.Length + enemies.Length)  // Turno de un enemigo
        {
            Debug.Log("Turno del enemigo: " + (currentTurnIndex - players.Length));
            playerAttacking = false;
            enemyAttacking = true;

            // Lógica para determinar qué enemigo ataca
            switch (GameManager.Instance.enemigoEnColision)
            {
                case 1:
                    enemigoUNO.TiradaAtaque();
                    break;
                case 2:
                    enemigoDOS.TiradaAtaque();
                    break;
                case 3:
                    enemigoTRES.TiradaAtaque();
                    break;
                case 4:
                    enemigoCUATRO.TiradaAtaque();
                    break;
                default:
                    Debug.LogWarning("Índice de enemigo inválido");
                    break;
            }
        }
    }

    // Método llamado por el botón de ataque del jugador
    public void PlayerAttack()
    {
        if (playerAttacking)
        {
            Debug.Log("El jugador ha atacado.");
            EndTurn();  // Cambia al siguiente turno
        }
    }

    // Método para finalizar el turno del jugador o enemigo y pasar al siguiente
    public void EndTurn()
    {
        currentTurnIndex = (currentTurnIndex + 1) % (players.Length + enemies.Length);  // Pasar al siguiente
        StartTurn();  // Iniciar el turno del siguiente jugador o enemigo
    }
}

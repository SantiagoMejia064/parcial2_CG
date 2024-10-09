using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemigo1 : MonoBehaviour
{
    public CombateManager combate;
    public EscenaManager escenaManager;


    [Header("Estadisticas")]
    public int fuerza;
    public int resistencia;

    public void Update(){
        
    }

    public void atacar(){
        TiradaDeExito();
        TiradaAtaque();
    }

    void Awake(){
        combate = GameObject.Find("CombateManager").GetComponent<CombateManager>();
        escenaManager = GameObject.Find("EsceneManager").GetComponent<EscenaManager>();
    }
    public bool TiradaDeExito()
    {
        int tirada = UnityEngine.Random.Range(0, 10); // Genera un n?mero aleatorio entre 0 y 9 (1D10)
        if (tirada <= 3)
        {
            Debug.Log(tirada + "Pifia en la tirada de exito, no se realiza accion.");
            combate.playerAttacking = true;
            combate.enemyAttacking = false;
            return false;

        }
        else
        {
            Debug.Log(tirada + "Tirada exitosa, el ataque continua.");

            int tirada1 = UnityEngine.Random.Range(0, 10);
            int tirada2 = UnityEngine.Random.Range(0, 10);

            int valorAtaque = int.Parse(tirada1.ToString() + tirada2.ToString());

            Debug.Log("Tirada de ataque de personaje 1: " + tirada1 + "+" + tirada2 + " = " + valorAtaque);

            if (valorAtaque > 70 && valorAtaque <= 99)
            {
                Debug.Log("Pifia en el ataque del enemigo 1, no se hace da�o.");
                combate.playerAttacking = true;
                combate.enemyAttacking = false;
                return false;
            }
            else if (valorAtaque < 70 && valorAtaque > fuerza)
            {
                Debug.Log("El ataque del enemigo 1 es exitoso, supera la fuerza del personaje.");
                combate.playerAttacking = true;
                combate.enemyAttacking = false;
                return true;
            }
            else
            {
                Debug.Log("El ataque del enemiigo 1 no es exitoso, no supera la fuerza del personaje.");
                combate.playerAttacking = true;
                combate.enemyAttacking = false;
                return false;
            }
        }
    }

    public void TiradaAtaque()
    {
        if (TiradaDeExito())
        {
            int d6 = UnityEngine.Random.Range(0, 6);

            int valorAtaque = d6;
            Debug.Log("El personaje hizo el siguiente daño: " + d6 +  " = " + valorAtaque);

            Player1Attack playerScript = GameObject.FindObjectOfType<Player1Attack>();
            if (playerScript != null)
            {
                playerScript.GetDamage(valorAtaque);  // Aplicar el daño al jugador usando GetDamage
            }
            else
            {
                Debug.LogWarning("No se encontró el script del jugador para aplicar daño.");
            }



            Debug.Log("El turno del enemigo terminó, turno del jugador activado.");
            combate.playerAttacking = true;
            combate.enemyAttacking = false;
            combate.ActivatePlayerAttackButtons(true);
        }
        else
        {
            Debug.Log("El ataque del enemigo falló.");

            // Aun si el ataque del enemigo falla, devolvemos el turno al jugador
            Debug.Log("El turno del enemigo terminó, turno del jugador activado.");
            combate.playerAttacking = true;
            combate.enemyAttacking = false;

            // Activar los botones de ataque del jugador
            combate.ActivatePlayerAttackButtons(true);
        }
    }

    public void GetDamage(int dmg)
    {
        resistencia -= dmg;  // Resta la cantidad de da?o
        Dead();
    }

    public void Dead()
    {
        if (resistencia <= 0)
        {
            Invoke("DestruirPersonaje", 1f);  // Espera 1 segundos antes de destruir el objeto
            escenaManager.inicioJuego();
        }
    }

    public void DestruirPersonaje()
    {
        Destroy(gameObject);  // Destruye el objeto donde est? este script (el jugador)
    }

    public void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            Debug.Log("Enemigo en colision: 1");
            GameManager.Instance.SetEnemigoEnColision(1);
            Debug.Log("Será que si cambia el numero " + GameManager.Instance.enemigoEnColision);
            Destroy(GameManager.Instance.gameObject);
            escenaManager.irCombate();
        }
    }
}



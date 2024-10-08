using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemigo1 : MonoBehaviour
{
    public CombateManager combate;
    public EscenaManager escenaManager;
    public GameObject P1;
    public GameObject P2;
    public GameObject P3;
    public GameObject P4;

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
                Debug.Log("Pifia en el ataque de personaje 1, no se hace da�o.");
                combate.playerAttacking = true;
                combate.enemyAttacking = false;
                return false;
            }
            else if (valorAtaque < 70 && valorAtaque > fuerza)
            {
                Debug.Log("El ataque de personaje 1 es exitoso, supera la fuerza del personaje.");
                combate.playerAttacking = true;
                combate.enemyAttacking = false;
                return true;
            }
            else
            {
                Debug.Log("El ataque de personaje 1 no es exitoso, no supera la fuerza del personaje.");
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
            Debug.Log("El personaje hizo el siguiente da�o: " + d6 +  " = " + valorAtaque);

            combate.playerAttacking = true;
            combate.enemyAttacking = false;
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
            P1.transform.position = GameManager.Instance.punto;
            //escenaManager.inicioJuego();
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
            Destroy(collision.gameObject);
            escenaManager.irCombate();
        }
    }
}



using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Player1Attack : MonoBehaviour
{
    
    //public static PlayerManager Instance { get; private set; }

    public GameObject Player;
    public CombateManager combate;

    //public EscenaManager escenaManager;

    [Header("Estadisticas")]
    public int fuerza;
    public int resistencia;

    public bool TiradaDeExito()
    {
        int tirada = Random.Range(0, 10); // Genera un n�mero aleatorio entre 0 y 9 (1D10)
        if (tirada <= 3)
        {
            Debug.Log(tirada + "Pifia en la tirada de exito, no se realiza accion.");
            return false;

        }
        else
        {
            Debug.Log(tirada + "Tirada exitosa, el ataque continua.");

            int tirada1 = Random.Range(0, 10);
            int tirada2 = Random.Range(0, 10);

            int valorAtaque = int.Parse(tirada1.ToString() + tirada2.ToString());

            Debug.Log("Tirada de ataque de personaje 1: " + tirada1 + "+" + tirada2 + " = " + valorAtaque);

            if (valorAtaque > 70 && valorAtaque <= 99)
            {
                Debug.Log("Pifia en el ataque de personaje 1, no se hace daño.");
                return false;
            }
            else if (valorAtaque < 70 && valorAtaque > fuerza)
            {
                Debug.Log("El ataque de personaje 1 es exitoso, supera la fuerza del personaje.");
                return true;
            }
            else
            {
                Debug.Log("El ataque de personaje 1 no es exitoso, no supera la fuerza del personaje.");
                return false;
            }
        }
    }

    public void TiradaAtaque()
    {
        if (TiradaDeExito())
        {
            int d10 = Random.Range(0, 10);
            int d4 = Random.Range(0, 4);

            int valorAtaque = d10 + d4;
            Debug.Log("El personaje hizo el siguiente daño: " + d10 + "+" + d4 + " = " + valorAtaque);

            //Enemigo1.getDamage(valorAtaque);

            combate.playerAttacking = false;
            combate.enemyAttacking = true;    
        }
    }


    public void TiradaAtaque2()
    {
        if (TiradaDeExito())
        {
            int d6A = Random.Range(0, 6);
            int d6B = Random.Range(0, 6);

            int valorAtaque = d6A + d6B;
            Debug.Log("El personaje hizo el siguiente daño: " + d6A + "+" + d6B + " = " + valorAtaque);

            //Enemigo1.getDamage(valorAtaque);

            combate.playerAttacking = false;
            combate.enemyAttacking = true;    
        }
    }

    public void GetDamage(int dmg)
    {
        resistencia -= dmg;  // Resta la cantidad de da�o
        Dead();
    }

    public void Dead()
    {
        if (resistencia <= 0)
        {
            Invoke("DestruirPersonaje", 1f);  // Espera 1 segundos antes de destruir el objeto
            //escenaManager.inicioJuego();
        }
    }

    public void DestruirPersonaje()
    {
        Destroy(gameObject);  // Destruye el objeto donde est� este script (el jugador)
    }
}
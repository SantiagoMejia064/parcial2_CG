using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Player2Attack : MonoBehaviour
{
    
    //public static PlayerManager Instance { get; private set; }

    public GameObject Player;
    public CombateManager combate;

    [Header("Estadisticas")]
    public int salud;
    public int fuerza;
    public int resistencia;

    /*
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    */

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

            Debug.Log("Tirada de ataque de personaje 2: " + tirada1 + "+" + tirada2 + " = " + valorAtaque);

            if (valorAtaque > 70 && valorAtaque <= 99)
            {
                Debug.Log("Pifia en el ataque de personaje 2, no se hace daño.");
                return false;
            }
            else if (valorAtaque < 70 && valorAtaque > fuerza)
            {
                int danoRealizado = fuerza;
                Debug.Log("Ataque de personaje 2 exitoso, daño realizado: " + danoRealizado);
                return true;
            }
            else
            {
                Debug.Log("El ataque de personaje 2 no es exitoso, no supera la fuerza del personaje.");
                return false;
            }
        }
    }

    public void TiradaAtaque()
    {
        if (TiradaDeExito())
        {
            int d10 = Random.Range(0, 10);

            int valorAtaque = d10;
            Debug.Log("Tirada de ataque de personaje 2: " + d10 + " = " + valorAtaque);

            //Enemigo1.getDamage(valorAtaque);

            combate.playerAttacking = false;
            combate.enemyAttacking = true;
        }
    }


    public void TiradaAtaque2()
    {
        if (TiradaDeExito())
        {
            int d10 = Random.Range(0, 10);
            int d4 = Random.Range(0, 4);

            int valorAtaque = d10 + d4;
            Debug.Log("Tirada de ataque de personaje 2: " + d10 + "+" + d4 + " = " + valorAtaque);

            //Enemigo1.getDamage(valorAtaque);

            combate.playerAttacking = false;
            combate.enemyAttacking = true;
        }
    }

    public void TiradaAtaque3()
    {
        if (TiradaDeExito())
        {
            int d10 = Random.Range(0, 10);
            int d4 = Random.Range(0, 4);
            int D4 = Random.Range(0, 4);


            int valorAtaque = d10 + d4 + D4;
            Debug.Log("Tirada de ataque de personaje 2: " + d10 + "+" +d4 + "+" + D4 + "=" + valorAtaque);

            //Enemigo1.getDamage(valorAtaque);

            combate.playerAttacking = false;
            combate.enemyAttacking = true;
        }
    }

    public void GetDamage(int dmg)
    {
        salud -= dmg;  // Resta la cantidad de da�o
        Dead();
    }

    public void Dead()
    {
        if (salud <= 0)
        {
            Invoke("DestruirPersonaje", 1f);  // Espera 1 segundos antes de destruir el objeto
        }
    }

    public void DestruirPersonaje()
    {
        Destroy(gameObject);  // Destruye el objeto donde est� este script (el jugador)
    }
}
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Player2Attack : MonoBehaviour
{
    
    //public static PlayerManager Instance { get; private set; }

    public GameObject Player;

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
    public void Update()
    {
        /*
        if (Input.GetButtonDown("Fire1"))
        {
            TiradaAtaque();
        }
        */
    }
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
            return true;
        }
    }

    public void TiradaAtaque()
    {
        if (TiradaDeExito())
        {
            int tirada1 = Random.Range(0, 10);
            int tirada2 = Random.Range(0, 4);

            int valorAtaque = int.Parse(tirada1.ToString() + tirada2.ToString());

            Debug.Log("Tirada de ataque de personaje 1: " + tirada1 + "+" + tirada2 + " = " + valorAtaque);

            if (valorAtaque > 70 && valorAtaque <= 99)
            {
                Debug.Log("Pifia en el ataque de personaje 1, no se hace daño.");
            }
            else if (valorAtaque < 70 && valorAtaque > fuerza)
            {

                int danoRealizado = fuerza;

                Debug.Log("Ataque de personaje 1 exitoso, daño realizado: " + danoRealizado);
            }
            else
            {
                Debug.Log("El ataque de personaje 1 no es exitoso, no supera la fuerza del personaje.");
            }
        }
    }


    public void TiradaAtaque2()
    {
        int tirada1 = Random.Range(0, 6);
        int tirada2 = Random.Range(0, 6);

        int valorAtaque = int.Parse(tirada1.ToString() + tirada2.ToString());

        Debug.Log("Tirada de ataque2 de personaje 1: " + tirada1 + tirada2 + " = " + valorAtaque);

        if (valorAtaque > 70 && valorAtaque <= 99)
        {
            Debug.Log("Pifia en el ataque2 de personaje 1, no se hace da�o.");
        }
        else if (valorAtaque < 70 && valorAtaque > fuerza)
        {
            int danoRealizado = fuerza;
            Debug.Log("Ataque2 de personaje 1 exitoso, dano realizado: " + danoRealizado);
        }
        else
        {
            Debug.Log("El ataque2 de personaje 1 no es exitoso, no supera la fuerza del personaje.");
        }
    }

    public void TiradaAtaque3()
    {
        int tirada1 = Random.Range(0, 6);
        int tirada2 = Random.Range(0, 6);

        int valorAtaque = int.Parse(tirada1.ToString() + tirada2.ToString());

        Debug.Log("Tirada de ataque2 de personaje 1: " + tirada1 + tirada2 + " = " + valorAtaque);

        if (valorAtaque > 70 && valorAtaque <= 99)
        {
            Debug.Log("Pifia en el ataque2 de personaje 1, no se hace da�o.");
        }
        else if (valorAtaque < 70 && valorAtaque > fuerza)
        {
            int danoRealizado = fuerza;
            Debug.Log("Ataque2 de personaje 1 exitoso, dano realizado: " + danoRealizado);
        }
        else
        {
            Debug.Log("El ataque2 de personaje 1 no es exitoso, no supera la fuerza del personaje.");
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lupus : MonoBehaviour
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
        if (tirada > 7 && tirada <= 9)
        {
            Debug.Log(tirada + "Pifia en la tirada de exito, Lupus no ataca.");
            combate.playerAttacking = false;
            combate.enemyAttacking = true;
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
            int d8 = UnityEngine.Random.Range(0, 9);
            int d4 = UnityEngine.Random.Range(0, 5);

            int valorAtaque = d8 + d4;
            Debug.Log("El personaje hizo el siguiente daño = " + valorAtaque);


            combate.playerAttacking = false;
            combate.enemyAttacking = true;
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
            //escenaManager.inicioJuego();
        }
    }

    public void DestruirPersonaje()
    {
        Destroy(gameObject);  // Destruye el objeto donde est? este script (el jugador)
    }

}

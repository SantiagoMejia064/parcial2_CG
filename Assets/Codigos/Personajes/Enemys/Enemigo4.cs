using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo4 : MonoBehaviour
{
    public CombateManager combate;
    public EscenaManager escenaManager;

    [Header("Estadisticas")]
    public int fuerza;
    public int resistencia;

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
        int tirada = Random.Range(0, 10); // Genera un n?mero aleatorio entre 0 y 9 (1D10)
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
                Debug.Log("Pifia en el ataque de personaje 1, no se hace da�o.");
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

            int valorAtaque = d10;
            Debug.Log("El personaje hizo el siguiente da�o: " + d10 + " = " + valorAtaque);

            //Player.getDamage(valorAtaque);

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

    public void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            Debug.Log("Enemigo en colision: 4");
            GameManager.Instance.SetEnemigoEnColision(4);
            Debug.Log("Será que si cambia el numero " + GameManager.Instance.enemigoEnColision);
            Destroy(collision.gameObject);
            escenaManager.irCombate();
        }
    }
}

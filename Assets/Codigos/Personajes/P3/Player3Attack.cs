using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3Attack : MonoBehaviour
{
    public GameObject Player;
    public CombateManager combate;

    public Enemigo1 enemigo1;
    public Enemigo2 enemigo2;
    public Enemigo3 enemigo3;
    public Enemigo4 enemigo4;
    private int valorAtaque;

    [Header("Estadisticas")]
    public int fuerza;
    public int resistencia;

    private Animator anim;

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

            Debug.Log("Tirada de ataque de personaje 3: " + tirada1 + "+" + tirada2 + " = " + valorAtaque);

            if (valorAtaque > 70 && valorAtaque <= 99)
            {
                Debug.Log("Pifia en el ataque de personaje 3, no se hace da�o.");
                return false;
            }
            else if (valorAtaque < 70 && valorAtaque > fuerza)
            {
                
                Debug.Log("Ataque de personaje 3 exitoso, supera la fuerza del Personaje");
                return true;
            }
            else
            {
                Debug.Log("El ataque de personaje 3 no es exitoso, no supera la fuerza del personaje.");
                return false;
            }
        }
    }

    public void atacar(){

        Debug.Log("Atacando al enemigo en colisión: " + GameManager.Instance.enemigoEnColision);
        switch(GameManager.Instance.enemigoEnColision){
                case 1:
                    enemigo1.GetDamage(valorAtaque);
                    break;
                case 2:
                    enemigo2.GetDamage(valorAtaque);
                    break;
                case 3:
                    enemigo3.GetDamage(valorAtaque);
                    break;
                case 4:
                    enemigo4.GetDamage(valorAtaque);
                    break;
                default:
                    Debug.LogWarning("indice de enemigo invalido");
                    Debug.Log(GameManager.Instance.enemigoEnColision);
                    break;
            }

            combate.playerAttacking = false;
            combate.enemyAttacking = true;   
    }

    public void TiradaAtaque()
    {
        combate.ActivatePlayerAttackButtons(false);
        if (TiradaDeExito())
        {
            int d10 = Random.Range(0, 10);
            int d6 = Random.Range(0, 6);

            int valorAtaque = d10 + d6;
            GameManager.Instance.SetRetroalimentación("El personaje hizo el siguiente daño: " + valorAtaque);
            anim.SetTrigger("Ataque1");
            combate.enemyAttacking = true;
            StartCoroutine(combate.eleccionAtaqueEnemigo());
        }
        else
        {
            GameManager.Instance.SetRetroalimentación("El ataque del jugador falló");
            combate.enemyAttacking = true;

            
            StartCoroutine(combate.eleccionAtaqueEnemigo());
        // Si el ataque falla, también quieres que los botones se desactiven y pase al turno del enemigo
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

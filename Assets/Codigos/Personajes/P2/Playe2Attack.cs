using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Player2Attack : MonoBehaviour
{
    public GameObject Player;
    public CombateManager combate;
    public Enemigo1 enemigo1;
    public Enemigo2 enemigo2;
    public Enemigo3 enemigo3;
    public Enemigo4 enemigo4;

    [Header("Estadisticas")]
    public int fuerza;
    public int resistencia;

    private int valorAtaque;
    private Animator anim;

    void Awake(){
        anim = GetComponent<Animator>();
    }
    public bool TiradaDeExito()
    {
        int tirada = Random.Range(0, 10);
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

                Debug.Log("Ataque de personaje 2 exitoso, supera la fuerza del Personaje");
                return true;
            }
            else
            {
                Debug.Log("El ataque de personaje 2 no es exitoso, no supera la fuerza del personaje.");
                return false;
            }
        }
    }

    public void atacar(){
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
                    break;
            }

            combate.playerAttacking = false;
            combate.enemyAttacking = true;
    }

    public void TiradaAtaque()
    {
        if (TiradaDeExito())
        {
            int d10 = Random.Range(0, 10);

            valorAtaque = d10;
            Debug.Log("Tirada de ataque de personaje 2: " + d10 + " = " + valorAtaque);
            anim.SetTrigger("Ataque1");

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

            valorAtaque = d10 + d4;

            Debug.Log("Tirada de ataque de personaje 2: " + d10 + "+" + d4 + " = " + valorAtaque);
            anim.SetTrigger("Ataque2");
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


            valorAtaque = d10 + d4 + D4;
            
            Debug.Log("Tirada de ataque de personaje 2: " + d10 + "+" +d4 + "+" + D4 + "=" + valorAtaque);
            anim.SetTrigger("Ataque3");
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
        }
    }

    public void DestruirPersonaje()
    {
        Destroy(gameObject);  // Destruye el objeto donde est� este script (el jugador)
    }
}
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Player1Attack : MonoBehaviour
{

    public GameObject Player;
    public CombateManager combate;
    public Enemigo1 enemigo1;
    public Enemigo2 enemigo2;
    public Enemigo3 enemigo3;
    public Enemigo4 enemigo4;
    private int valorAtaque;

    //public EscenaManager escenaManager;

    [Header("Estadisticas")]
    public int fuerza;
    public int resistencia;

    private Animator anim;

    void Awake(){
        anim = GetComponent<Animator>();
    }

    public Player1Attack(int fuerza, int resistencia){
        this.fuerza = fuerza;
        this.resistencia = resistencia;
    }

    public Player1Attack clone(){
        return  new Player1Attack(fuerza, resistencia);
    }

    public bool TiradaDeExito()
    {
        int tirada = Random.Range(0, 10); // Genera un n�mero aleatorio entre 0 y 9 (1D10)
        if (tirada <= 3)
        {
            GameManager.Instance.SetRetroalimentación("Pifia en al tirada de exito");
            combate.playerAttacking = false;
            combate.enemyAttacking = true; 
            return false;

        }
        else
        {
            int tirada1 = Random.Range(0, 10);
            int tirada2 = Random.Range(0, 10);

            int valorAtaque = int.Parse(tirada1.ToString() + tirada2.ToString());

            if (valorAtaque > 70 && valorAtaque <= 99)
            {
                GameManager.Instance.SetRetroalimentación("Pifia en al tirada de exito");
                combate.playerAttacking = false;
                combate.enemyAttacking = true; 
                return false;
            }
            else if (valorAtaque < 70 && valorAtaque > fuerza)
            {
                combate.playerAttacking = false;
                combate.enemyAttacking = true; 
                return true;
            }
            else
            {
                GameManager.Instance.SetRetroalimentación("Pifia en al tirada de exito");
                combate.playerAttacking = false;
                combate.enemyAttacking = true; 
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
        combate.ActivatePlayerAttackButtons(false);
        if (TiradaDeExito())
        {
            int d10 = Random.Range(0, 10);
            int d4 = Random.Range(0, 4);

            valorAtaque = d10 + d4;
            
            Debug.Log("El personaje hizo el siguiente daño: " + valorAtaque);
            anim.SetTrigger("Ataque1");
            combate.enemyAttacking = true;
            StartCoroutine(combate.eleccionAtaqueEnemigo());
        }
        else
        {
            GameManager.Instance.SetRetroalimentación("Pifia en al tirada de exito");
            combate.enemyAttacking = true;

            
            StartCoroutine(combate.eleccionAtaqueEnemigo());
        // Si el ataque falla, también quieres que los botones se desactiven y pase al turno del enemigo
        }

    }


    public void TiradaAtaque2()
    {
        if (TiradaDeExito())
        {
            int d6A = Random.Range(0, 6);
            int d6B = Random.Range(0, 6);

            valorAtaque = d6A + d6B;
            Debug.Log("El personaje hizo el siguiente daño: " + d6A + "+" + d6B + " = " + valorAtaque);
            anim.SetTrigger("Ataque2");
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
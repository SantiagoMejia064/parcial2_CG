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
            Debug.Log(tirada + "Pifia en la tirada de exito, no se realiza accion.");
            combate.playerAttacking = false;
            combate.enemyAttacking = true; 
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
                combate.playerAttacking = false;
                combate.enemyAttacking = true; 
                return false;
            }
            else if (valorAtaque < 70 && valorAtaque > fuerza)
            {
                Debug.Log("El ataque de personaje 1 es exitoso, supera la fuerza del personaje.");
                combate.playerAttacking = false;
                combate.enemyAttacking = true; 
                return true;
            }
            else
            {
                Debug.Log("El ataque de personaje 1 no es exitoso, no supera la fuerza del personaje.");
                combate.playerAttacking = false;
                combate.enemyAttacking = true; 
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
            int d4 = Random.Range(0, 4);

            valorAtaque = d10 + d4;
            
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


    public void TiradaAtaque2()
    {
        combate.ActivatePlayerAttackButtons(false);
        if (TiradaDeExito())
        {
            int d6A = Random.Range(0, 6);
            int d6B = Random.Range(0, 6);

            valorAtaque = d6A + d6B;

            GameManager.Instance.SetRetroalimentación("El personaje hizo el siguiente daño: " + valorAtaque);
            anim.SetTrigger("Ataque2");
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
        resistencia -= dmg;  // Resta la cantidad de da�o
        GameManager.Instance.vidaJugador.text = "Vida Jugador: " + resistencia;  // Actualiza el texto de vida del enemigo
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
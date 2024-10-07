using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Lupus : MonoBehaviour
{
    public CombateManager combate;
    public EscenaManager escenaManager;
    public Player1Attack player1;
    public Player2Attack player2;
    public Player3Attack player3;
    public Player4Attack player4;
    public Elena elena;
    private int valorAtaque;

    [Header("Estadisticas")]
    public int fuerza;
    public int resistencia;

    void Awake(){
        combate = GameObject.Find("CombateManager").GetComponent<CombateManager>();
        escenaManager = GameObject.Find("EsceneManager").GetComponent<EscenaManager>();
        player1 = GameObject.Find("Player1").GetComponent<Player1Attack>();
        player2 = GameObject.Find("Player2").GetComponent<Player2Attack>();
        player3 = GameObject.Find("Player3").GetComponent<Player3Attack>();
        player4 = GameObject.Find("Player4").GetComponent<Player4Attack>();
    }

    public void atacar(){
        int ayuda = Random.Range(0,1);
        if(ayuda == 0){
            if(TiradaDeExito()){
                TiradaAtaque();
                elena.TiradaAtaque();
                int jugadorAtacar = UnityEngine.Random.Range(1, 5);
                switch(jugadorAtacar){
                    case 1:
                        player1.GetDamage(valorAtaque);
                        combate.playerAttacking = true;
                        combate.enemyAttacking = false;
                        break;
                    case 2:
                        player2.GetDamage(valorAtaque);
                        combate.playerAttacking = true;
                        combate.enemyAttacking = false;
                        break;
                    case 3:
                        player3.GetDamage(valorAtaque);
                        combate.playerAttacking = true;
                        combate.enemyAttacking = false;
                        break;
                    case 4:
                        player4.GetDamage(valorAtaque);
                        combate.playerAttacking = true;
                        combate.enemyAttacking = false;
                        break;
                    default:
                        Debug.LogWarning("indice de enemigo invalido");
                        break;
                }
            }
        }else{
            if(TiradaDeExito()){
                TiradaAtaque();
                int jugadorAtacar = UnityEngine.Random.Range(1, 5);
                switch(jugadorAtacar){
                    case 1:
                        player1.GetDamage(valorAtaque);
                        combate.playerAttacking = true;
                        combate.enemyAttacking = false;
                        break;
                    case 2:
                        player2.GetDamage(valorAtaque);
                        combate.playerAttacking = true;
                        combate.enemyAttacking = false;
                        break;
                    case 3:
                        player3.GetDamage(valorAtaque);
                        combate.playerAttacking = true;
                        combate.enemyAttacking = false;
                        break;
                    case 4:
                        player4.GetDamage(valorAtaque);
                        combate.playerAttacking = true;
                        combate.enemyAttacking = false;
                        break;
                    default:
                        Debug.LogWarning("indice de enemigo invalido");
                        break;
                }
            }
        }
    }

    
    public bool TiradaDeExito()
    {
        int tirada = UnityEngine.Random.Range(0, 10);
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
            int ataque = UnityEngine.Random.Range(1,3);
            if(ataque == 1){
                int d4 = UnityEngine.Random.Range(0, 5);
                int d6 = UnityEngine.Random.Range(0, 7);

                valorAtaque = d4 + d6;
            }else{
                int d6A = UnityEngine.Random.Range(0, 7);
                int d6B = UnityEngine.Random.Range(0, 7);

                valorAtaque = d6A + d6B;
            }
    }

    public void GetDamage(int dmg)
    {
        resistencia -= dmg;  // Resta la cantidad de daño
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
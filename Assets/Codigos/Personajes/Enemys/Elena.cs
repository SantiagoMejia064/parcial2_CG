using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elena : MonoBehaviour
{
        public CombateManager combate;
    public EscenaManager escenaManager;
    private int valorAtaque;

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
    
    public int TiradaAtaque()
    {
        if (TiradaDeExito())
        {
            int d8 = UnityEngine.Random.Range(0, 9);
            
            valorAtaque = d8;
        }
        return valorAtaque;
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
            GameManager.Instance.elenaLife = false;
            //escenaManager.inicioJuego();
        }
    }

    public void DestruirPersonaje()
    {
        Destroy(gameObject);  // Destruye el objeto donde est? este script (el jugador)
    }

}

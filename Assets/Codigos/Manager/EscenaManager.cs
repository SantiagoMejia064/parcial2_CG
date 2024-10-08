using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenaManager : MonoBehaviour
{
    public float tiempoEsc;
    public bool aparecerEnemigo = true;
    [SerializeField] private float time;
    
    public void inicioJuego(){
        SceneManager.LoadScene("Juego", LoadSceneMode.Single);
        //Debug.Log("Tiene " + GameManager.Instance.cantLlaveMorada + " llaves moradas");
        Debug.Log(GameManager.Instance.cantGemas);
        Debug.Log(GameManager.Instance.cantEspadas);
        Debug.Log(GameManager.Instance.cantPociones);
    }

    public void finJuego(){
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void escenaFinal(){
        SceneManager.LoadScene("Final", LoadSceneMode.Single); 
    }

    public void nivelBoss(){
        SceneManager.LoadScene("Boss", LoadSceneMode.Single);
    }

    public void irPueblo ()
    {
        SceneManager.LoadScene("Town", LoadSceneMode.Single);
    }

    public void irCombate(){
        SceneManager.LoadScene("Combate", LoadSceneMode.Single);
        Debug.Log("Enemigo en colision: " + GameManager.Instance.enemigoEnColision);
    }

    public void salirJuego(){
        Application.Quit();
    }
}
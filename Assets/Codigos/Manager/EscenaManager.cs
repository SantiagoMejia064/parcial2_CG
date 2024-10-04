using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenaManager : MonoBehaviour
{

    public static EscenaManager instance { get; private set; }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
    public void inicioJuego(){
        SceneManager.LoadScene("Juego", LoadSceneMode.Single);
        Debug.Log("Tiene " + GameManager.Instance.cantLlaveMorada + " llaves moradas");
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
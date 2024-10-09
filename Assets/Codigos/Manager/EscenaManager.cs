using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenaManager : MonoBehaviour
{
    public GameObject P1;
    public GameObject P2;
    public GameObject P3;
    public GameObject P4;
    public float tiempoEsc;
    public bool aparecerEnemigo = true;
    [SerializeField] private float time;
    
    public void inicioJuego(){
        SceneManager.LoadScene("Juego", LoadSceneMode.Single);
        for (int i = 0; i < GameManager.Instance.ListEnemigos.Count; i++)
        {
            Instantiate(GameManager.Instance.ListEnemigos[i], GameManager.Instance.ListEnemigos[i].transform.position, GameManager.Instance.ListEnemigos[i].transform.rotation);
        }
        /*
        P1.transform.position = GameManager.Instance.punto;
        P2.transform.position = GameManager.Instance.punto; 
        P3.transform.position = GameManager.Instance.punto;
        P4.transform.position = GameManager.Instance.punto;
        */
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
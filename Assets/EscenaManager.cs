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
//            DontDestroyOnLoad(gameObject);
        }
    }
    
    public void inicioJuego(){
        SceneManager.LoadScene("Juego", LoadSceneMode.Single);
    }

    public void finJuego(){
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void irBosque(){
        SceneManager.LoadScene("Bosque", LoadSceneMode.Single); 
    }

    public void nivelBoss(){
        SceneManager.LoadScene("Final", LoadSceneMode.Single);
    }

    public void salirJuego(){
        Application.Quit();
    }
}
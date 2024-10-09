using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public List<GameObject> ListEnemigos = new List<GameObject>();

    [SerializeField] public int enemigoEnColision;

    public Vector3 punto;
    public bool inJuego = false;
    public bool inBosque = false;
    public bool inBoss = false;

    public int cantLlaveMorada = 0;

    public int cantGemas = 0;
    public int cantEspadas = 0;
    public int cantPociones = 0;

    public Player1Attack player1;
    public Player2Attack player2;
    public Player3Attack player3;
    public Player4Attack player4;
    public CombateManager combate;

    public Text vidaJugador; 
    public Text vidaEnemigo;  
    public Text textoCombate;
    public Text pocion;
    public Text gema;
    public Text espada;

    private void Awake(){
        if (Instance != null && Instance != this){
            Destroy(this);
        }
        else{
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        if(SceneManager.GetActiveScene().name == "Town" || SceneManager.GetActiveScene().name == "Juego" || SceneManager.GetActiveScene().name == "Boss"){
            pocion = GameObject.Find("txt_pocion").GetComponent<Text>();
            gema = GameObject.Find("txt_gema").GetComponent<Text>();
            espada = GameObject.Find("txt_espada").GetComponent<Text>();
            textoCombate = GameObject.Find("principalTxt").GetComponent<Text>();
            vidaJugador = GameObject.Find("vidaJugador").GetComponent<Text>();  
            vidaEnemigo = GameObject.Find("vidaEnemigo").GetComponent<Text>();
        }

        if(SceneManager.GetActiveScene().name == "Combate")
        {
            combate = GameObject.Find("CombateManager").GetComponent<CombateManager>();   
        }
        
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Juego" && inJuego == false)
        {
            Debug.Log("Estoy en el juego");

            inJuego = true;
        }

        switch (combate.currentPlayer)
        {
            case 1:
                vidaJugador.text = "Vida: " + player1.resistencia;
                break;
            case 2:
                vidaJugador.text = "Vida: " + player2.resistencia;
                break;
            case 3:
                vidaJugador.text = "Vida: " + player3.resistencia;
                break;
            case 4:
                vidaJugador.text = "Vida: " + player4.resistencia;
                break;
        }



    }


    public void SetLlavesMoradas()
    {
        cantLlaveMorada++;
    }

    public void SetGemas()
    {
        cantGemas++;
        gema.text = "Gemas: " + cantGemas.ToString();
    }

    public void SetEspadas()
    {
        cantEspadas++;
        espada.text = "Espadas: " + cantEspadas.ToString();
    }

    public void SetPociones()
    {
        cantPociones++;
        pocion.text = "Pociones: " + cantPociones.ToString();
    }
    
    public void SetEnemigoEnColision(int enemigo)
    {
        enemigoEnColision = enemigo;
    }

    public void SetRetroalimentación(string mensaje)
    {
        if (textoCombate != null)
        {
            textoCombate.text = mensaje;
        }
        else
        {
            Debug.LogWarning("No se ha asignado el componente Text para retroalimentación.");
        }
    }

    public void ActualizarVidaUI(int vidaJugadors, int vidaEnemigos)
    {
        if (vidaJugador != null)
        {
            vidaJugador.text = "Vida Jugador: " + vidaJugadors.ToString();
        }

        if (vidaEnemigo != null)
        {
            vidaEnemigo.text = "Vida Enemigo: " + vidaEnemigos.ToString();
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] public int enemigoEnColision;

    public Vector3 punto;
    public bool inJuego = false;
    public bool inBosque = false;
    public bool inBoss = false;

    public int cantLlaveMorada = 0;

    public int cantGemas = 0;
    public int cantEspadas = 0;
    public int cantPociones = 0;

    public Text retroalimentación;
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
        }
        
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Juego" && inJuego == false)
        {
            Debug.Log("Estoy en el juego");

            inJuego = true;
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

    public void SetRetroalimentación(string texto)
    {
        retroalimentación.text = texto;

    }


}

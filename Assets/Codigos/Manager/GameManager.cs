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
    /*
    [SerializeField] public GameObject[] enemigos;
    [SerializeField] public GameObject[] posEnemigos;
    */
    public Vector3 punto;
    public bool inJuego = false;
    public bool inBosque = false;
    public bool inBoss = false;

    public int cantLlaveMorada = 0;

    public int cantGemas = 0;
    public int cantEspadas = 0;
    public int cantPociones = 0;

    // retro
    public Text retroalimentación;
    public string textRetro;

    //public Text llavesMoradas;

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

        if(SceneManager.GetActiveScene().name == "Combate")
        {
            retroalimentación = GameObject.Find("TextoRet").GetComponent<Text>();

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

/*
    public void SetEnemigoAzar(){
        if(SceneManager.GetActiveScene().name == "Juego"){
            Debug.Log("Enemigos en la escena: " + enemigos.Length);
            Debug.Log("Posiciones en la escena: " + posEnemigos.Length);
                
            int posicionEnemigos = Random.Range(1,posEnemigos.Length);
            for (int i = 0; i < posicionEnemigos; i++)
            {
                int seleccionEnemigos = Random.Range(1, enemigos.Length);
                if(null != enemigos[seleccionEnemigos]){
                        Instantiate(enemigos[seleccionEnemigos], posEnemigos[i].transform.position, posEnemigos[i].transform.rotation);
                }
            }
        }
    }
*/

    public void SetLlavesMoradas()
    {
        cantLlaveMorada++;
        //llavesMoradas.text = "Llaves Moradas: " + cantLlaveMorada.ToString();
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
        textRetro = texto;
        retroalimentación.text = textRetro.ToString();
        

    }


}

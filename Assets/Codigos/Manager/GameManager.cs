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
    [SerializeField] public GameObject[] enemigos;
    [SerializeField] public GameObject[] posEnemigos;

    public int cantLlaveMorada = 0;
    //public Text llavesMoradas;
    private void Awake(){
        if (Instance != null && Instance != this){
            Destroy(this);
        }
        else{
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SetEnemigoAzar(){

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

    public void SetLlavesMoradas()
    {
        cantLlaveMorada++;
        //llavesMoradas.text = "Llaves Moradas: " + cantLlaveMorada.ToString();
    }

    public void SetEnemigoEnColision(int enemigo)
    {
        enemigoEnColision = enemigo;
    }
}

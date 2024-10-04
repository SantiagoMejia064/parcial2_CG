using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] public int enemigoEnColision;
    [SerializeField] public GameObject[] enemigos;
    [SerializeField] public GameObject[] posEnemigos;

    public int cantLlaveMorada = 0;
    //public Text llavesMoradas;


    public void SetEnemigoAzar(){
        int posicionEnemigos = Random.Range(1,posEnemigos.Length);
        

        Debug.Log(posicionEnemigos);
        for (int i = 0; i < posicionEnemigos; i++)
        {
            int seleccionEnemigos = Random.Range(1, enemigos.Length);

            Debug.Log("Entré");
            Instantiate(enemigos[seleccionEnemigos], posEnemigos[i].transform.position, posEnemigos[i].transform.rotation);
            
            /*
            actEnemigos = Random.Range(0, 2);
            if (actEnemigos == 1)
            {
                //enemigos[i].GetComponent<GameObject>().SetActive(true);
                enemigos[i].SetActive(true);
            }else{
                enemigos[i].SetActive(false);   
            }*/
        }
    }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }


    }

    public void SetLlavesMoradas()
    {
        Debug.Log("Se ha obtenido una llave morada");
        cantLlaveMorada++;
        //llavesMoradas.text = "Llaves Moradas: " + cantLlaveMorada.ToString();
    }

    public void SetEnemigoEnColision(int enemigo)
    {
        enemigoEnColision = enemigo;
    }
}

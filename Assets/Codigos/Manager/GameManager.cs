using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] public int enemigoEnColision;

    public int cantLlaveMorada = 0;
    //public Text llavesMoradas;
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

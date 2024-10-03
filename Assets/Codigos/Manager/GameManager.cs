using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public Transform punto;

    public int cantLlaveMorada = 0;
    //public Text llavesMoradas;
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

    public void SetLlavesMoradas()
    {
        Debug.Log("Se ha obtenido una llave morada");
        cantLlaveMorada++;
        //llavesMoradas.text = "Llaves Moradas: " + cantLlaveMorada.ToString();
    }
}

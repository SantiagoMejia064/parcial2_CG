using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField]
    public Rigidbody rb;

    [Header("Movimiento")]
    public float horizontal;
    public float velocidad = 5f;

    [Header("Salto")]
    public float speedSalto = 8f;
    public Transform checkPiso;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

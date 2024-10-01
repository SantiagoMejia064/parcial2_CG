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
    public LayerMask layerPiso;
    public int contJ;
    public bool canJump;


    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        /*
        if(horizontal > 0 || horiontal <= 0)
        {

        }
        */
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Woman : MonoBehaviour
{
    public GameObject personaje1;    // Referencia al personaje 1 (jugador)
    public float distanciaActivacion = 5f;  // Distancia mínima para activar el movimiento
    public float velocidadMovimiento = 2f;  // Velocidad de movimiento hacia la izquierda
    private bool moviendoIzquierda = false; // Estado para saber si el personaje 2 debe moverse


    void Start()
    {
        
    }

    void Update()
    {
        // Calcula la distancia entre personaje 1 y personaje 2
        float distancia = Vector2.Distance(personaje1.transform.position, transform.position);

        // Si la distancia es menor o igual a la distancia de activación, empieza el movimiento
        if (distancia <= distanciaActivacion && !moviendoIzquierda)
        {
            moviendoIzquierda = true;  // Inicia el movimiento hacia la izquierda
        }

        // Si se activa el movimiento, mueve al personaje 2 hacia la izquierda
        if (moviendoIzquierda)
        {
            MoverIzquierda();
        }
    }

    void MoverIzquierda()
    {
        // Asegúrate de que el movimiento sea hacia la izquierda usando Translate con -1 en el eje x
        transform.position += new Vector3(-velocidadMovimiento * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Desaparicion"))
        {
            Destroy(gameObject);  // Destruye el objeto al colisionar
        }
    }

    
}

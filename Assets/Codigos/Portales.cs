using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Portales : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject Player3;
    public GameObject Player4;
    public Transform destination;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            float distanciaP1 = Vector2.Distance(player1.transform.position, transform.position);
            float distanciaP2 = Vector2.Distance(player2.transform.position, transform.position);
            float distanciaP3 = Vector2.Distance(Player3.transform.position, transform.position);
            float distanciaP4 = Vector2.Distance(Player4.transform.position, transform.position);
            if(distanciaP1 > 0.3f && distanciaP2 > 0.3f && distanciaP3 > 0.3f && distanciaP4 > 0.3f)
            {
                player1.transform.position = destination.transform.position;
                player2.transform.position = destination.transform.position;
                Player3.transform.position = destination.transform.position;
                Player4.transform.position = destination.transform.position;
            }
        }
    }
}
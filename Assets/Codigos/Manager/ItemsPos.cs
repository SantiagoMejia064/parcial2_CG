using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsPos : MonoBehaviour
{
    public Transform[] itemPos;
    public GameObject[] itemPrefab;

    private void Awake()
    {
        int posicionEnemigos = Random.Range(1, itemPos.Length);
        
        for (int i = 0; i < posicionEnemigos; i++)
        {
            int seleccionEnemigos = Random.Range(1, itemPrefab.Length);
            if (null != itemPrefab[seleccionEnemigos])
            {
                Instantiate(itemPrefab[seleccionEnemigos], itemPos[i].transform.position, itemPos[i].transform.rotation);
            }
        }
    }
}

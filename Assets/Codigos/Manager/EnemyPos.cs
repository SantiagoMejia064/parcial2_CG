using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPos : MonoBehaviour
{
    public Transform[] enemyPos;
    public GameObject[] enemyPrefab;
   

    private void Awake()
    {
        
        
            int posicionEnemigos = Random.Range(1, enemyPos.Length);
            for (int i = 0; i < posicionEnemigos; i++)
            {
                int seleccionEnemigos = Random.Range(1, enemyPrefab.Length);
                if (null != enemyPrefab[seleccionEnemigos])
                {   
                        Instantiate(enemyPrefab[seleccionEnemigos], enemyPos[i].transform.position, enemyPos[i].transform.rotation);
                }
            }
        
    }
}

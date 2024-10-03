using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemigo1 : MonoBehaviour
{
    public void atacar(){
        CombateManager combateManager = GameObject.Find("CombateManager").GetComponent<CombateManager>();
        Debug.Log("Atacando");
        combateManager.playerAttacking = true;
        combateManager.enemyAttacking = false;
    }


}

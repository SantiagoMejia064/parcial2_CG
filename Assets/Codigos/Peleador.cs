using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Peleador : MonoBehaviour
{
    public CombateManager combatemanager;
    // Start is called before the first frame update
    public abstract void InitTurn();
}

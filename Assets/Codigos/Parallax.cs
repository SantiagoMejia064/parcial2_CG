using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] 
    private Vector2 velMovi;

    private Vector2 offset;
     private Material mat;
     private Rigidbody2D rb;


    private void Awake()
    {
        mat = GetComponent<Renderer>().material;
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb != null)
        {
            offset = rb.velocity.x * 0.1f * velMovi * Time.deltaTime;
            mat.mainTextureOffset += offset;
        }

    }
}

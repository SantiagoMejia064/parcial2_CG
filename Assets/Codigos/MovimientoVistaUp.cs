using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoVistaUp : MonoBehaviour
{
    [SerializeField]
    public Rigidbody2D rb;

    [Header("Movimiento")]
    public float horizontal;
    public float vertical;
    public float velocidad = 5f;
    private bool mirandoDerecha = true;
    public bool attack = false;

    //[Header("Animaci�n")]
    //public Animator anim;

    // private Vector2 startPoint;

    //public AudioSource salto;
    //public AudioSource caminar;

    //private Vector2 startPoint;

    //public AudioSource moneda;

    private void Awake()
    {
        //anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (attack == false)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");

            transform.position += new Vector3(horizontal,0f,0f) * velocidad * Time.deltaTime;
            transform.position += new Vector3(0f, vertical, 0f) * velocidad * Time.deltaTime;

            // Caminar
            if (horizontal > 0 || horizontal <= 0){
                //anim.SetFloat("Walk", Mathf.Abs(horizontal));
            }
            else{
                //anim.SetFloat("Walk", 0);
            }

            if (Input.GetButtonDown("Horizontal")){
                //caminar.Play();
            }
            else{
                //caminar.Stop();
            }

            voltear();
        }
    }

    private void voltear()
    {
        if (mirandoDerecha && horizontal < 0f || !mirandoDerecha && horizontal > 0f)
        {
            mirandoDerecha = !mirandoDerecha;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    
    // Para simulaciones fisicas es recomendable el FixedUpdate
    private void FixedUpdate()
    {
        //rb.velocity = new Vector2(horizontal*velocidad, rb.velocity.y);
        
        //rb.AddForce(Vector2.right * horizontal * velocidad, ForceMode2D.Force);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlataformaMovil")
        {
            transform.parent = collision.transform;
        }
    }

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Moneda")
        {
            GameManager.Instance.SetMonedas();

            Debug.Log(GameManager.Instance.cantMonedas);

            Destroy(collision.gameObject);

            moneda.Play();
        }
    }
    */
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlataformaMovil")
        {
            transform.parent = null;
        }
    }
    
}

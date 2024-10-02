using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlataforma : MonoBehaviour
{
    [SerializeField]
    public Rigidbody2D rb;

    [Header("Movimiento")]
    public float horizontal;
    public float velocidad = 5f;
    private bool mirandoDerecha = true;
    public bool attack = false;

    [Header("Salto")]
    public float speedSalto = 8f;
    public Transform checkPiso;
    public LayerMask layerPiso;
    public int contJ;
    public bool canJump;

    
    public bool isCrouching = false;

    [Header("Animaci�n")]
    public Animator anim;

    // private Vector2 startPoint;

    //public AudioSource salto;
    //public AudioSource caminar;

    //private Vector2 startPoint;

    //public AudioSource moneda;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (attack == false)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            anim.SetFloat("Jumping", 1);

            // Saltar
            if (Input.GetButtonDown("Jump") && isGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, speedSalto);

                if (contJ > 1)
                {
                    canJump = false;
                }
                contJ++;
                anim.SetFloat("Jumping", 1);
                //salto.Play();

                Debug.Log(contJ);
            }

            if (Input.GetButtonDown("Jump") && !isGrounded() && canJump == true)
            {
                rb.velocity = new Vector2(rb.velocity.x, speedSalto);

                if (contJ >= 1)
                {
                    canJump = false;
                }
                contJ++;
                anim.SetFloat("Jumping", 1);
                //salto.Play();

                Debug.Log(contJ);
            }

            if (rb.velocity.y <= 0 && isGrounded())
            {
                contJ = 0;
                canJump = true;
                anim.SetFloat("Jumping", 0);
            }

            // Caminar
            if (horizontal > 0 || horizontal <= 0)
            {
                anim.SetFloat("Walk", Mathf.Abs(horizontal));
            }
            else
            {
                anim.SetFloat("Walk", 0);
            }

            if (Input.GetButtonDown("Horizontal") && isGrounded())
            {
                //caminar.Play();
            }
            else
            {
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
        rb.velocity = new Vector2(horizontal*velocidad, rb.velocity.y);
        
        //rb.AddForce(Vector2.right * horizontal * velocidad, ForceMode2D.Force);
        
    }
    

    public bool isGrounded()
    {
        return Physics2D.OverlapCircle(checkPiso.position, 0.2f, layerPiso);
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

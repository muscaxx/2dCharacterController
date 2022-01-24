using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public int h�z;
    public float z�plama_kuvveti;
    private float harekety�n�;
    private Rigidbody2D rb;
    private bool karaktersagyuz = true;

    //jump
    private bool zemin;
    public Transform zeminKontrol;
    public float yar�capkontrol;
    public LayerMask zeminNe;
    public int z�plama;
 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        harekety�n� = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(harekety�n� * h�z, rb.velocity.y);

        if (karaktersagyuz == false && harekety�n� > 0)
        {
            Flip();
        }
        else if (karaktersagyuz == true && harekety�n� < 0)
        {
            Flip();
        }

        //jump
        zemin = Physics2D.OverlapCircle(zeminKontrol.position, yar�capkontrol, zeminNe);

    }

    public void Flip()
    {
        karaktersagyuz = !karaktersagyuz;
        Vector2 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && z�plama > 0)
        {
            rb.velocity = Vector2.up * z�plama_kuvveti;
            z�plama--;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && z�plama ==0 && zemin ==true)
        {
            rb.velocity = Vector2.up * z�plama_kuvveti;
        }
        if(zemin == true)
        {
            z�plama = 1;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public int hýz;
    public float zýplama_kuvveti;
    private float hareketyönü;
    private Rigidbody2D rb;
    private bool karaktersagyuz = true;

    //jump
    private bool zemin;
    public Transform zeminKontrol;
    public float yarýcapkontrol;
    public LayerMask zeminNe;
    public int zýplama;
 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        hareketyönü = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(hareketyönü * hýz, rb.velocity.y);

        if (karaktersagyuz == false && hareketyönü > 0)
        {
            Flip();
        }
        else if (karaktersagyuz == true && hareketyönü < 0)
        {
            Flip();
        }

        //jump
        zemin = Physics2D.OverlapCircle(zeminKontrol.position, yarýcapkontrol, zeminNe);

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
        if (Input.GetKeyDown(KeyCode.Space) && zýplama > 0)
        {
            rb.velocity = Vector2.up * zýplama_kuvveti;
            zýplama--;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && zýplama ==0 && zemin ==true)
        {
            rb.velocity = Vector2.up * zýplama_kuvveti;
        }
        if(zemin == true)
        {
            zýplama = 1;
        }
    }
}

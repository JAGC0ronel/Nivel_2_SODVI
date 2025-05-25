using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlataformaMovil"))
        {
            // Hacer que el jugador sea hijo de la plataforma
            transform.SetParent(collision.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlataformaMovil"))
        {
            // Dejar de ser hijo de la plataforma
            transform.SetParent(null);
        }
    }


    bool derecha = false;
    bool izquierda = false;
    bool salto = false;
    bool Ensuelo;

    public Rigidbody2D rb;
    public float Velocidad;
    public float saltoalto;

    public void irderecha()
    {
        derecha = true;
    }
    public void noderecha() 
    {
        derecha = false;
    }
    public void irizquierda()
    {
        izquierda = true;
    }
    public void noizquierda()
    {
        izquierda = false;
    }

    public void saltar()
    {
            salto = true;   
    }

    private void FixedUpdate()
    {
        if (derecha)
        {
            rb.AddForce(new Vector2 (-Velocidad, 0)*Time.deltaTime);
        }
        if (izquierda)
        {
            rb.AddForce(new Vector2(Velocidad, 0) * Time.deltaTime);
        }
        if (salto)
        {
            salto = false;
            rb.AddForce(new Vector2(0, saltoalto));
        }
    }
}

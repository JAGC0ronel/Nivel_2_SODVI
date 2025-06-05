using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.StandaloneInputModule;

public class PlayerScript : MonoBehaviour
{
    public Animator animator;
    private bool mirarIzquierda = true;
    bool derecha = false;
    bool izquierda = false;
    bool salto = false;
    bool EnSuelo;

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

    private void Update()
    {
        float velocidadX = 0f;

        if (derecha)
        {
            velocidadX = -Velocidad;
            rb.AddForce(new Vector2(-Velocidad, 0) * Time.deltaTime);

            // Si estamos yendo a la derecha pero miramos a la izquierda, giramos
            if (!mirarIzquierda)
            {
                Flip();
            }
        }

        if (izquierda)
        {
            velocidadX = Velocidad;
            rb.AddForce(new Vector2(Velocidad, 0) * Time.deltaTime);

            // Si estamos yendo a la izquierda pero miramos a la derecha, giramos
            if (mirarIzquierda)
            {
                Flip();
            }
        }

        if (salto)
        {
            salto = false;
            rb.AddForce(new Vector2(0, saltoalto));
        }

        // Actualiza el parámetro del animator
        animator.SetFloat("movement", Mathf.Abs(velocidadX));
    }

    // Método para girar el sprite
    void Flip()
    {
        // Cambia el estado de la dirección
        mirarIzquierda = !mirarIzquierda;

        // Obtiene la escala actual
        Vector3 escala = transform.localScale;

        // Invierte la escala en X
        escala.x *= -1;

        // Aplica la nueva escala
        transform.localScale = escala;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlataformaMovil"))
        {
            // Espera un frame antes de asignar el padre para evitar errores
            StartCoroutine(AsignarPadreDespues(collision.transform));
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlataformaMovil"))
        {
            transform.SetParent(null);
        }
    }

    private IEnumerator AsignarPadreDespues(Transform nuevaPlataforma)
    {
        yield return null; // espera 1 frame
        transform.SetParent(nuevaPlataforma);
    }
}
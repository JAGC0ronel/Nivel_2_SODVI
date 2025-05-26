using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    [Header("Configuración de Movimiento")]
    [SerializeField] private float velocidad = 2f; // Velocidad de movimiento
    [SerializeField] private float distancia = 3f; // Distancia de movimiento
    [SerializeField] private float tiempoEspera = 1f; // Tiempo entre cambios de dirección

    private Vector3 posicionInicial;
    private bool movimientoActivado = false;
    private Rigidbody2D rb;

    private void Start()
    {
        posicionInicial = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    public void RecibirBooleano(bool valor)
    {
        Debug.Log("Booleano recibido: " + valor);
        if (valor && !movimientoActivado)
        {
            movimientoActivado = true;
            StartCoroutine(MoverPlataforma());
        }
    }

    IEnumerator MoverPlataforma()
    {
        while (movimientoActivado)
        {
            Vector3 destinoIzquierda = posicionInicial + Vector3.left * distancia;
            Vector3 destinoDerecha = posicionInicial + Vector3.right * distancia;

            while (Vector3.Distance(transform.position, destinoIzquierda) > 0.1f)
            {
                rb.MovePosition(Vector3.MoveTowards(transform.position, destinoIzquierda, velocidad * Time.fixedDeltaTime));
                yield return new WaitForFixedUpdate();
            }

            yield return new WaitForSeconds(tiempoEspera);

            while (Vector3.Distance(transform.position, destinoDerecha) > 0.1f)
            {
                rb.MovePosition(Vector3.MoveTowards(transform.position, destinoDerecha, velocidad * Time.fixedDeltaTime));
                yield return new WaitForFixedUpdate();
            }

            yield return new WaitForSeconds(tiempoEspera);

            while (Vector3.Distance(transform.position, posicionInicial) > 0.1f)
            {
                rb.MovePosition(Vector3.MoveTowards(transform.position, posicionInicial, velocidad * Time.fixedDeltaTime));
                yield return new WaitForFixedUpdate();
            }

            yield return new WaitForSeconds(tiempoEspera);
        }
    }
}

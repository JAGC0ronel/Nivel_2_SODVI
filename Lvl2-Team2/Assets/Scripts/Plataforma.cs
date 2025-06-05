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
        // Definir los dos puntos de destino
        Vector3 destinoIzquierda = posicionInicial + Vector3.left * distancia;
        Vector3 destinoDerecha = posicionInicial + Vector3.right * distancia;

        // Comenzar moviéndose hacia la izquierda (o el primer destino)
        Vector3 destinoActual = destinoIzquierda;
        Vector3 siguienteDestino = destinoDerecha;

        while (movimientoActivado)
        {
            // Moverse hacia el destino actual
            while (Vector3.Distance(transform.position, destinoActual) > 0.1f)
            {
                rb.MovePosition(Vector3.MoveTowards(transform.position, destinoActual, velocidad * Time.fixedDeltaTime));
                yield return new WaitForFixedUpdate();
            }

            // Esperar en el destino
            yield return new WaitForSeconds(tiempoEspera);

            // Intercambiar destinos para el próximo movimiento
            Vector3 temp = destinoActual;
            destinoActual = siguienteDestino;
            siguienteDestino = temp;
        }
    }
}
